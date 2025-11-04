CREATE USER 'application_user' IDENTIFIED BY '1234';
grant all on *.* to 'application_user'@'%';
FLUSH PRIVILEGES;

-- Create database
CREATE DATABASE IF NOT EXISTS op_validator;

-- Switch to the new database
USE op_validator;

-- Create table: personnummer
CREATE TABLE IF NOT EXISTS personnummer (
    id INT AUTO_INCREMENT PRIMARY KEY,
    value VARCHAR(13) NOT NULL,
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create table: samordningsnummer
CREATE TABLE IF NOT EXISTS samordningsnummer (
    id INT AUTO_INCREMENT PRIMARY KEY,
    value VARCHAR(13) NOT NULL,
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create table: organisationsnummer
CREATE TABLE IF NOT EXISTS organisationsnummer (
    id INT AUTO_INCREMENT PRIMARY KEY,
    value VARCHAR(13) NOT NULL,
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
