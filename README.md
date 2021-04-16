# Gaint Bomb Challenge

# Summary
This is a simple web site with no authentication. Page loads with a list of movies available for rent. Search box at the top of the screen lets you search by name. Pagination has been provided at the bottom. To rent the movies click Add to Cart button. Same movie is not allowed to be rented more than once.
Click the checkout button to navigate to the next page. 
Since the application does not use a database, unfortunately an anti-pattern is implemented. Session had to used to keep track of items in the cart as the user is navigated to a different MVC page. Had this to be an SPA, session wouldn't have been needed.
Make Payment button is a dummy button that clears the cart and redirects to the search page.

# Project Structure
ASP.Net MVC template used with Web API.
SearchService is created to convert data returned from the API to a viewModel object. This service is injected via the constructor and the dependency is resolved using the Unity framework.
ApiHelper is a wrapper around the the GiantBomb API. This makes the SearchService testable as the ApiHelper is injected as a dependency.

On the frontend gameRentalAppModule is create which is initialized when the Search and Checkout pages are loaded. Under Scripts/Components there are two AngularJS controllers one for each page.

Stylesheets with the same name as the component are added under the content folder to keep the styles separate. Page specific styles if needed can be added for the page specific div id. This can help to keep styles specific to the page.

# Technology stack
The application is developed with AngularJS v1.8.2 and ASP.Net MVC 5 with Web API
Moq for unit testing
Visual Studio Community edition was the IDE of choice.

# Running the application
The application used IIS Express, so all that is needed is to be opened in Visual Studio and then run.

# What could have done better
Exception handling unfortunately limited to logging error on the console.
Angular Service can be created to encasulate the $http service
UI is basic using bootstrap