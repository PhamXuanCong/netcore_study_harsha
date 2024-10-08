﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace ServiceNews;

public class CountriesService: ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        if(countryAddRequest == null)
            throw new ArgumentNullException(nameof(countryAddRequest));
        
        if (countryAddRequest.CountryName == null)
        {
            throw new ArgumentException(nameof(countryAddRequest.CountryName));
        }
        
        if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
        {
            throw new ArgumentException("Given country name already exists");
        }

        Country country = countryAddRequest.ToCountry();

        country.CountryId = Guid.NewGuid();
        
        _countries.Add(country);

        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
        return _countries.Select(ct => ct.ToCountryResponse()).ToList();
    }

    public CountryResponse? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId == null)
            return null;

        Country? countryResponseFromList = _countries.FirstOrDefault(x => x.CountryId == countryId);

        if (countryResponseFromList == null)
            return null;

        return countryResponseFromList.ToCountryResponse();
    }
}