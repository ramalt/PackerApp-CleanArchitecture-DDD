using NSubstitute;
using PackerApp.Application.Commands;
using PackerApp.Application.Commands.Handlers;
using PackerApp.Application.Dtos;
using PackerApp.Application.Exceptions;
using PackerApp.Application.Services;
using PackerApp.Domain.Entities;
using PackerApp.Domain.Enums;
using PackerApp.Domain.Factoires;
using PackerApp.Domain.Repositories;
using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Commands;
using Shouldly;

namespace PackerApp.UnitTest.Application;

public class CreatePackingListWithItemsTests
{
    private readonly ICommandHandler<CreatePackingListWithItemsCommand> _commandHandler;
    private readonly IPackingListRepository _repository;
    private readonly IWeatherService _weatherService;
    private readonly IPackingListReadService _readService;
    private readonly IPackingListFactory _factory;

    public CreatePackingListWithItemsTests()
    {
        _repository = Substitute.For<IPackingListRepository>();
        _weatherService = Substitute.For<IWeatherService>();
        _readService = Substitute.For<IPackingListReadService>();
        _factory = Substitute.For<IPackingListFactory>();

        _commandHandler = new CreatePackingListWithItemsCommandHandler(_repository, _readService, _factory, _weatherService);
    }
    Task Act(CreatePackingListWithItemsCommand command) => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_same_Name_Already_Exists()
    {
        var command = new CreatePackingListWithItemsCommand(Guid.NewGuid(), "MyList", 10, Gender.Female, default);
        _readService.ExistByNameAsync(command.Name).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingListAlreadyExistException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_Returned_From_Service()
    {
        var command = new CreatePackingListWithItemsCommand(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new LocalizationWriteModel("Warsaw", "Poland"));

        _readService.ExistByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MissingLocalizationWeatherException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var command = new CreatePackingListWithItemsCommand(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new LocalizationWriteModel("Warsaw", "Poland"));

        _readService.ExistByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(12));

        _factory.CreateWithDefaultItems(
            id: command.Id,
            name: command.Name,
            gender: command.Gender,
            days: command.Days,
            localization: Arg.Any<Localization>(),
            temprature: Arg.Any<Temprature>()).Returns(default(PackingList));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();
        await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
    }


}
