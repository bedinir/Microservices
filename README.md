## Microservices Project Overview

The microservices project is composed of several services responsible for different functionalities. Below is an overview of each service:

### Mango.Services.AuthAPI

This service is responsible for handling authentication and authorization within the application. It provides endpoints for user authentication, user registration, and token generation.

### Mango.Services.CuponApi

The CuponApi service manages coupons within the application. It provides endpoints for creating, retrieving, updating, and deleting coupons.

### Mango.Web

The Mango.Web service serves as the front end of the application, providing a user interface for interacting with the various functionalities offered by the microservices. It consumes the AuthAPI and CuponApi services to provide authentication, authorization, and coupon management features to users.


### Running the Project

To run the microservices project locally:

1. Navigate to each microservice directory (`Mango.Services.AuthAPI`, `Mango.Services.CuponApi`, `Mango.Web`) in your terminal.
2. Follow the instructions provided in each service's README to set up and run the service.
3. Once all services are running, you can access the web application at the specified URL.
