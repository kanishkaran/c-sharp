# Web API

This project is a **Web API** built using **ASP.NET Core** that provides CRUD (Create, Read, Update, Delete) operations for managing products. It uses an in-memory database for data storage and demonstrates best practices for building RESTful APIs.

## Features

- **Create**: Add a new product to the database.
- **Read**: Retrieve all products or a specific product by ID.
- **Update**: Modify the details of an existing product.
- **Delete**: Remove a product from the database.
- **Error Handling**: Centralized error handling with a custom error controller.
- **Logging**: Logs important actions and warnings for better traceability.
- **Swagger Integration**: API documentation and testing using Swagger UI.

## Endpoints

### 1. Get All Products
- **Method**: `GET`
- **URL**: `/api/product`
- **Description**: Fetches a list of all products.

### 2. Get Product by ID
- **Method**: `GET`
- **URL**: `/api/product/{id}`
- **Description**: Fetches a specific product by its ID.

### 3. Create a Product
- **Method**: `POST`
- **URL**: `/api/product`
- **Description**: Adds a new product.
- **Request Body**:
  ```json
  {
    "name": "Product Name"
  }

### 4. Update a Product
- **Method**: `PUT`
- **URL**: `/api/product/{id}`
- **Description**: Updates an existing product.
- **Request Body**:
  ```json
  {
    "name": "Update Product Name"
  }

### 5. Delete a Product
- **Method**: `DELETE`
- **URL**: `/api/product/{id}`
- **Description**: Deletes a product by its ID.

### Project Structure

- **Controllers**:
  - **ProductController**: Handles API requests for product management, including CRUD operations.
  - **ErrorController**: Manages centralized error responses for consistent error handling.

- **Models**:
  - **Product**: Represents the product entity with properties such as `Id` and `Name`.

- **Services**:
  - **IProductService**: Defines the interface for product-related operations (e.g., Create, Read, Update, Delete).
  - **ProductService**: Implements the `IProductService` interface to provide the actual logic for managing products.

- **Data**:
  - **AppDbContext**: An in-memory database context used for managing product data during runtime.


### Screenshot

![Image](./images/image.png)