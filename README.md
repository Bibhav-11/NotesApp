# Notes App

## Overview

This Notes App is designed for easy note-taking and organization. It is built with a client-side using React and Material UI, backed by a .NET-based server, and utilizes SQL Server for efficient data storage. It functions similar to Google Keep.

## Features

### Client-Side

- **React and Material UI**: The client-side of this app is developed using React for building a responsive user interface. Material UI components are used for a sleek and modern design.

- **Note Creation and Management**: Users can easily create, edit, and delete notes.

### Database Side

- **Code-First Approach**: The app implements a Code-First approach to database design, allowing for flexible and efficient database schema generation based on your model classes.

- **One-to-Many and Many-to-Many Relationships**: The database supports relationships such as one-to-many (Note and NoteActivity) and many-to-many (Note and NoteLabel) to ensure structured data organization.

### Backend Side in .NET

- **Repository Pattern**: The backend follows the Repository Pattern to abstract data access and provide a clean separation between database operations and the rest of the application.

- **DTO (Data Transfer Object)**: DTOs are used to transfer data between the API and the client, ensuring only necessary data is sent and received.

- **REST API**: The backend exposes a RESTful API that handles CRUD (Create, Read, Update, Delete) operations for notes and related entities.

### Upcoming Features

- **Note Label Introduction in Client Side**: Introduction of Note Labels to categorize and organize notes more effectively.

- **Redux Implementation**: Integration of Redux for state management in the client-side.

- **Authentication and Authorization Middleware**: Implementation of Authentication and Authorization middleware to secure the application and allow access control for users.
