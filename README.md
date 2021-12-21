# Getting Started

Quickly is an API for a simple project management tool for managing personal projects as well as large group projects. It uses Azure Blob Storage for storing contents, Postgre for SQL database and SendGrid API for mailing services. Furthermore, it uses Azure Cognitive Vision API to filter out adult and gore images uploaded to the system. To get started, follow the full API documentation below.


| Full API Reference           | Build Status                                                                                                                                                                             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| https://quickly.readme.io/ | [![Build & Generate API Reference](https://github.com/fffffatah/Quickly/actions/workflows/build.yaml/badge.svg)](https://github.com/fffffatah/Quickly/actions/workflows/build.yaml) |


## Setting Up
To build and run the project on your local machine make sure you have .NET 6, Azure Storage Emulator and Postgre 14 installed. Also, make sure you have the below environment variables set.

``
POSTGRE_SQL = {Your postgre database connection string}
``
``
SENDGRID_API_KEY = {Your SendGrid API key}
``
``
COGNITIVE_VISION_API = {Your Azure Cognitive API endpoint}
``
``
COGNITIVE_VISION_KEY = {Your Azure Cognitive API subscription key}
``
``
BLOB_CONN_STRING = {Your Azure Blob Storage connection string}
``
``
BLOB_CONTAINER = {Your Azure Blob Storage container name}
``
``
JWT_ISSUER = {Your JWT issuer}
``
``
JWT_KEY = {Your JWT key for token generation}
``