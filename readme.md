# SurveyMonkeyApiV3 - .Net v.4.0
C# Version 3 of the SurveyMonkey API

This project is active thanks to the effort of [@chrislott](https://github.com/chrislott).
I forked it just to add some initial documentation.
I will keep it around, updated with changes from @crislott 's version, but with .Net v.4 instead of v.4.5.

## Requirements

I am using this project with Visual Studio 2015, but I assume that it would work with VS2010 and all intermediate versions as well.
It also requires NuGet package manager, so you should install it if your VS version does not include it.

## Caveats

The accompanying test project requires an App.config file, which is not included in the project repo.
You can safely add your own or copy App.config.sample to start with.
It should include at least SurveyMonkeyAuthToken and SurveyMonkeyApiKey appSettings values which are required for the test.
If you don't know what these values refer to, take a look at the [SurveyMonkey documentation](https://developer.surveymonkey.com/api/v3/)
