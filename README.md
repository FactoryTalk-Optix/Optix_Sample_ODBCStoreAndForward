# Store and Forward to ODBC Database

This sample project shows how to connect to a remote MySQL server with Store and Forward capabilities.

## Setup procedure

### 1. Setup of the MySQL instance

1. On a device with Docker and the composer plugin installed, create the following `docker-compose.yml` file:

```yaml
services:
  # Database
  db:
    image: mysql:latest
    volumes:
      - db_data:/var/lib/mysql
    restart: always
    ports:
      - "3306:3306"
    environment:
      MYSQL_ROOT_PASSWORD: r00tp4ssw0rd
      MYSQL_DATABASE: database
      MYSQL_USER: sqluser
      MYSQL_PASSWORD: sqlp4ssw0rd

  # phpmyadmin
  phpmyadmin:
    depends_on:
      - db
    image: phpmyadmin:latest
    restart: always
    ports:
      - "8090:80"
    environment:
      PMA_HOST: db
      MYSQL_ROOT_PASSWORD: r00tp4ssw0rd

volumes:
  db_data:
```

2. Start the container using `docker compose up -d`.

### 2. Setup of the Optix project

1. Navigate to `DataStores/ODBCDatabase1/Server` and set the IP address of the machine where the MySQL instance is running.

### 3. Execution of the Optix project

Start the Optix project and observe the data being written to the MySQL instance.

The UI will show the data being written to the database. Please note: the trend will keep updating even if the Store is offline, as it was configured in `hybrid` mode, meaning it will be synched to the DataLogger and thus capable of accessing data in the Store and Forward cache.

You can also use phpMyAdmin (as configured in the Docker Compose file) to check the data being written to the database.

If the IP address or the TCP port of the MySQL instance is changed in the FactoryTalk Optix project, the Store and Forward feature will kick in storing the data locally until the connection is re-established.

As per FactoryTalk Optix 1.6.x, the Store and Forward is saved in RAM, this means that if the device is restarted, the data will be lost.

## Disclaimer

Rockwell Automation maintains these repositories for your convenience and that of other users. Although Rockwell Automation has the right at any time and for any reason to not access, edit, or remove content from this Repository, you acknowledge and agree to accept sole responsibility and liability for any Repository content posted, transmitted, downloaded, or used by you. Rockwell Automation has no obligation to monitor or update Repository content

The examples provided are to be used as a reference for building your own application and should not be used in production as-is. It is recommended to adapt the example for the purpose and observe the highest safety standards.