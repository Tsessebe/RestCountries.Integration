# RestCountries.Integration

RestCountries Integration is a http client to consume data from [Rest Countries API](https://restcountries.com/).

Target platform: .NET Core 5+

## Interface

```c#
Task<IEnumerable<Country>> GetAllAsync();
Task<Country> GetByNameAsync(string name);
Task<Country> GetByCodeAsync(string code);
```


## Setup guide
Install the package https://www.nuget.org/packages/RestCountries.Integration/ using nuget

Update your middleware
```c#
services.AddHttpClient<IRestCountriesService, RestCountriesService>();
```

Inject where needed
```c#
		private readonly IRestCountriesService countriesService;
        public HomeController(IRestCountriesService countriesService)
        {
            this.countriesService = countriesService;
        }
```

## Gotcha's

* None

## Versions

* 03 May 2022 - v1.0.0 Only parses limited number of fields

