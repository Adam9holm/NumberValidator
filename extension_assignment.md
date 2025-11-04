# Extension of Assignment for Experienced or Senior Developers

This extension assignment aims to assess your knowledge of software development along with common tools and practices in the field. Please follow common coding principles and patterns, and leave comments both for documentation and to explain design choices and trade-offs.

## Extension Assignment: Persisting Data and Validating Using External APIs

Implement the functionality to:

- Persist validated identifiers to a MySQL database.
- Extract persisted personal numbers based on birth year.

An additional part of validating the personal and coordination numbers should be to ensure that they are not one of the test numbers provided by Skatteverket.

- Endpoint documentation for Personal Numbers:  
  [Personal Numbers API](https://swagger.entryscape.com/?url=https%3A%2F%2Fskatteverket.entryscape.net%2Frowstore%2Fdataset%2Fb4de7df7-63c0-4e7e-bb59-1f156a591763%2Fswagger#/)

- Endpoint documentation for Coordination Numbers:  
  [Coordination Numbers API](https://swagger.entryscape.com/?url=https%3A%2F%2Fskatteverket.entryscape.net%2Frowstore%2Fdataset%2F9f29fe09-4dbc-4d2f-848f-7cffdd075383%2Fswagger)

## Technical Requirements

**All requirements from the original assignment apply to this extension assignment, except for the restriction on using only standard libraries.**  
In this extension assignment, you are allowed to use external libraries and dependencies in addition to standard libraries.

## MySQL Integration and Setup Using [Docker](https://www.docker.com/)

To assist in persisting data, the repository contains a [Dockerfile](./Dockerfile) to be used for the MySQL database and a SQL [initialization file](./init.sql).

- Build the image:  
  `docker build -t <chosen image tag/name> .`

- Validate build:  
  `docker images`

- Start the image/Run the database:  
  `docker run -d -p 3306:3306 <chosen image tag/name>`

- Investigate/Run commands on the image:  
  `docker exec -it <running image id> bash`

**Database credentials:**

- **Username:** application_user
- **Password:** 1234
