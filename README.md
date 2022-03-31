# Small automated UI-test based on Selenium and NUnit. 

Capabilities:
* Implemented basic framework for working with pages
* In **Resources/driverconfig.json** you can change browser resolution and available browsers(use "Chrome" or "Firefox" in "BrowserName")
* WebDriverManager, Loffer are used in solution
* Singleton and Page Object patterns are used in solution too

**Test case 1**
| Step                                                              | Expected result                              |
|-------------------------------------------------------------------|----------------------------------------------|
| Navigate to main page https://store.steampowered.com              | Main page is opened                          |
| Enter in the search bar 'Half-Life 3'. Click on the search button | Page with search result is opened            |
| Find game 'Half-Life 3' in the search result                      | 'Half-Life 3' is absent in the search result |

**Test case 2**
| Step                                                                                               | Expected result                                                                                   |
|----------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| Navigate to main page https://store.steampowered.com                                               | Main page is opened                                                                               |
| Move pointer to 'New & noteworthy' at page's menu. Wait pop-up menu. Click on 'Top sellers' button | Page with top sellers products is opened                                                          |
| Select checkbox 'Windows' in the right menu                                                        | Checkbox 'Windows' is ticked                                                                      |
| Select checkbox 'Single-player' in the right menu                                                  | Checkbox 'Single-player' is ticked                                                                |
| Set the slider in the 'Price' block in the position '$30'                                          | Price is $30                                                                                      |
| After searching get title, price and release date of the first product                             |                                                                                                   |
| Click on the first search result                                                                   | Page with product information is opened. Product information match information from previous step |