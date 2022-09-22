# GDS Razor · [![Test status](https://github.com/hippo-digital/gds-razor/actions/workflows/test.yml/badge.svg)](https://github.com/hippo-digital/gds-razor/actions/workflows/test.yml?query=branch%3Amaster)

Components from [govuk-frontend](https://github.com/alphagov/govuk-frontend) packaged as ASP.NET partial views.

To get started add the nuget package to your project and check out the examples in the [GdsRazorDemo](gds-razor/blob/master/GdsRazorDemo) project.

----
There are three projects in this repo:
### GdsRazor
Contains the actual components. This is the only project that is published.
### GdsRazorDemo
Mini-site with examples of every component so you can see what they look like.
### GdsRazorTest
Every component is tested for accessibility using [axe](https://github.com/dequelabs/axe-core) via [Selenium.Axe](https://github.com/TroyWalshProf/SeleniumAxeDotnet). Plus there are unit tests ported from the original repo.