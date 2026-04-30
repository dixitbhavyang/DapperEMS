-- DapperEMS Database Schema
-- Run this script to create the database from scratch

CREATE DATABASE DapperEMS;
GO

USE DapperEMS;
GO

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);
GO

-- Seed Data
INSERT INTO Departments (Name) VALUES ('Engineering'), ('HR'), ('Finance');

INSERT INTO Employees (Name, Email, Salary, DepartmentId) VALUES
('Bhavyang Dixit', 'bhavyang@example.com', 75000, 1),
('Rahul Shah', 'rahul@example.com', 55000, 2),
('Priya Mehta', 'priya@example.com', 65000, 3);
GO