# Use MySQL version 9.1.0
FROM mysql:9.1.0

# Set environment variables for MySQL root password
ENV MYSQL_ROOT_PASSWORD=password

# Copy the initialization SQL script into the container
COPY ./init.sql /docker-entrypoint-initdb.d/

# Expose port 3306 to the host machine
EXPOSE 3306
