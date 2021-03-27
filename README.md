![vrnz2_logo_p](https://user-images.githubusercontent.com/18154661/112667675-53338780-8e3c-11eb-93d2-0fd0f57e35ce.jpg)

## Vrnz2.ISO4217

... ISO4217 NuGet package resolver


## Technology 

Here are the technologies used in this project.

* DotNet Standard 2.0
* DotNet Core 3.1
* DotNet Core 5.0


## Services Used

* Github
* NuGet.org


## Getting started

* To install:
>    $ Install-Package Vrnz2.ISO4217

## How to use

In project 

https://github.com/Vernizze/Vrnz2.ISO4217/tree/main/UpdateIso4217DataSource.Example

We have a practical example of use, but is simple:

1. Add the package to your solution
2. Include the package to DI (if you use Microsoft.Extensions.DependencyInjection)
 2.1. Default interval (One day) => ```services.AddISO4217(30 * 1000);```
 2.2. With custom interval (30 seconds, p. example) =>  ```services.AddISO4217(30 * 1000);```
 2.3. Or call the method to register in auto update ISO4217 definitions (the param 'executionInterval' is optional miliseconds value to start the update process): 
 * ```UpdateIso4217DataSource.Handler.Instance.Handle();```
3. Search by Number:
 3.1. -> Getting 'Iso4217Definition' object
 * ```Iso4217Definition iso4217Number971ValueByNumber = GetIso4217InfoByNumber.Handler.Instance.GetDefinition(971);```
 3.2. -> Getting string Code value
 * ```string iso4217Number971CodeByNumber = GetIso4217InfoByNumber.Handler.Instance.GetCode(iso4217Number971ValueByNumber.Number);```
4. Search by Code:
 4.1. -> Getting 'Iso4217Definition' object
 * ```Iso4217Definition iso4217Number971ValueByCode = GetIso4217InfoByCode.Handler.Instance.GetDefinition(iso4217Number971ValueByNumber.Code);```
 4.2. -> Getting Nullable<int> Code value
 * ```Nullable<int> iso4217Number971NumberByCode = GetIso4217InfoByCode.Handler.Instance.GetNumber(iso4217Number971ValueByNumber.Code);```


## Features

  - Auto update ISO4219 code from https://www.currency-iso.org/dam/downloads/lists/list_one.xml every day or as configured in DI
  - Obtain all ISO4217 data from Number or Code of currency passing
  - Obtain only ISO4217 Number from Code or Code from Number passing


## Versioning

1.0.1.0


## Authors

* Carlos Vernizze: https://github.com/Vernizze


Please follow github and join us!
Thanks to visiting me and good coding!
