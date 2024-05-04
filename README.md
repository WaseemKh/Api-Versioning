# API-Versioning

Display How we use Version in .net wep API (URL,Query, and Header) 

*Note* Query it is fast and easer type to use .

## Features

- **In-memory database**: Utilizes Entity Framework Core for an in-memory database for simplicity and ease of development.
- **API Versioning**: Supports multiple versioning methods through query string, headers, and URL path.

## Getting Started

These instructions will get your copy of the project up and running on your local machine for development and testing purposes.

## Usage
Explain how API versioning is implemented:

- **Query String Versioning** : To specify an API version through a query string, use ?api-version=1.0 or define query in program.cs and use  ?hps-api-version=1.0.
- **Header Versioning** : To specify an API version through a request header, include X-API-Version: 1.0 .
- **URL Path Versioning** : Versioning can also be performed through the URL path, e.g., /api/v1/doctors.