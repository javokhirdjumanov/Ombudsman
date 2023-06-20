## Ombudsman System
### Diogramm: https://dbdiagram.io/d/643469488615191cfa8cc77c

This project aims to automate the documentation process. It is built using an entire architecture, including PostgreSql, EfCore, RestAPI, UnitOfWork Pattern, Singleton Pattern, and Data First Approach.

## Project Features

1. **Entire Architecture:** The project follows a well-structured architecture design.
2. **Database Diagram:** Check out the [database diagram](link_to_diagram) that consists of 30 tables.
3. **Multi-Language Support:** The application is localized to support multiple languages.
4. **Authentication and Authorization:** Implemented authentication and authorization features.
5. **Transaction Operations:** Child tables within a table are stored in the database using transaction operations.
6. **Document Filtering:** Developed a stored procedure to filter documents based on dates, which can be accessed using entities.
7. **Swagger Configuration:** Added configuration to set default DateTime.Now in Swagger.
8. **File Storage:** Utilized File Stream to store documents and saved them in the WWWROOT static file directory.
9. **Error Logging:** Implemented logging using Serilog to track and log errors.
10. **Extension Methods:** Created extension methods to validate and check Guid-based IDs.
11. **Middleware:** Implemented middleware to handle global exceptions and inject LanguageId and OrganizationId when the user is authorized.
12. **Custom Exceptions:** Developed custom exceptions and implemented them within the project.

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository: `git clone https://github.com/your_username/Menda-OmbudmanV2.git`
2. Set up the necessary environment variables.
3. Run the database migrations using Entity Framework Core.
4. Build and run the project.

## Contributing

Contributions are welcome! If you have any suggestions, bug reports, or feature requests, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](link_to_license).


