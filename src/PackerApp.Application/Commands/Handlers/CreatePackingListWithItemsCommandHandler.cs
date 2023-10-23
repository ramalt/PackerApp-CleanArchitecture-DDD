using PackerApp.Application.Exceptions;
using PackerApp.Application.Services;
using PackerApp.Application.Commands;
using PackerApp.Domain.Factoires;
using PackerApp.Domain.Repositories;
using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Commands;
using PackerApp.Domain.Entities;

namespace PackerApp.Application.Commands.Handlers;

public class CreatePackingListWithItemsCommandHandler : ICommandHandler<CreatePackingListWithItemsCommand>
{
    private readonly IPackingListReadService _readService;
    private readonly IPackingListRepository _repository;
    private readonly IPackingListFactory _factory;
    private readonly IWeatherService _weatherService;

    public CreatePackingListWithItemsCommandHandler(IPackingListRepository repository, IPackingListReadService readService, IPackingListFactory factory, IWeatherService weatherService)
    {
        _repository = repository;
        _readService = readService;
        _factory = factory;
        _weatherService = weatherService;
    }

    public async Task HandleAsync(CreatePackingListWithItemsCommand command)
    {
        var exist =  await _readService.ExistByNameAsync(command.Name);
        if(exist)
            throw new PackingListAlreadyExistException(command.Name);
        

        var localization = new Localization(command.Localization.City, command.Localization.Country);

        var weather = await _weatherService.GetWeatherAsync(localization);

        if(weather is null)
            throw new MissingLocalizationWeatherException(localization);

        var newPackingList = _factory.CreateWithDefaultItems(
            command.Id,
            command.Name,
            localization,
            command.Days,
            command.Gender,
            weather.Temperature
        );

        await _repository.AddAsync(newPackingList);
    }
}
