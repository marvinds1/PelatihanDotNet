CREATE DATABASE DB_DotNet;

USE DB_DotNet;

CREATE TABLE TableSpecification (
    TableId VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT(UUID()),
    TableNumber INT NOT NULL,
    ChairNumber INT NOT NULL,
    TablePic VARCHAR(75) NOT NULL,
    TableType VARCHAR(50) NULL
);

CREATE TABLE TableOrder (
    TableOrderId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableId VARCHAR(36) NOT NULL,
    MenuName VARCHAR(75) NOT NULL,
    QuantityOrder INT NULL,
    CONSTRAINT FK_TableOrder_TableSpecification FOREIGN KEY (TableId)
    REFERENCES TableSpecification(TableId)
);

-- Membuat Tabel One-to-One dengan TableSpecification
CREATE TABLE TableDetails (
    TableDetailId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableId VARCHAR(36) NOT NULL UNIQUE,
    Material VARCHAR(50) NOT NULL,
    Color VARCHAR(25) NOT NULL,
    FOREIGN KEY (TableId) REFERENCES TableSpecification(TableId)
);

-- Membuat Tabel Menu
CREATE TABLE Menu (
    MenuId VARCHAR(36) NOT NULL PRIMARY KEY,
    MenuName VARCHAR(75) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- Membuat Tabel Many-to-Many dengan TableOrder
CREATE TABLE TableOrderMenu (
    TableOrderId VARCHAR(36) NOT NULL,
    MenuId VARCHAR(36) NOT NULL,
    PRIMARY KEY (TableOrderId, MenuId),
    FOREIGN KEY (TableOrderId) REFERENCES TableOrder(TableOrderId),
    FOREIGN KEY (MenuId) REFERENCES Menu(MenuId)
);

INSERT INTO TableSpecification (TableId, TableNumber, ChairNumber, TablePic, TableType)
VALUES
    ('550e8400-e29b-41d4-a716-446655440000', 1, 4, 'table1.jpg', 'Dining'),
    ('550e8401-e29b-41d4-a716-446655440001', 2, 6, 'table2.jpg', 'Conference'),
    ('550e8402-e29b-41d4-a716-446655440002', 3, 2, 'table3.jpg', 'Coffee'),
    ('550e8403-e29b-41d4-a716-446655440003', 4, 8, 'table4.jpg', 'Dining'),
    ('550e8404-e29b-41d4-a716-446655440004', 5, 10, 'table5.jpg', 'Banquet');

INSERT INTO TableOrder (TableOrderId, TableId, MenuName, QuantityOrder)
VALUES
    ('660e8400-e29b-41d4-a716-446655440000', '550e8400-e29b-41d4-a716-446655440000', 'Pasta', 2),
    ('660e8401-e29b-41d4-a716-446655440001', '550e8401-e29b-41d4-a716-446655440001', 'Pizza', 3),
    ('660e8402-e29b-41d4-a716-446655440002', '550e8402-e29b-41d4-a716-446655440002', 'Coffee', 1),
    ('660e8403-e29b-41d4-a716-446655440003', '550e8403-e29b-41d4-a716-446655440003', 'Salad', 4),
    ('660e8403-e29b-41d4-a716-446655440004', '550e8403-e29b-41d4-a716-446655440003', 'Salad', 2),
    ('660e8404-e29b-41d4-a716-446655440005', '550e8404-e29b-41d4-a716-446655440004', 'Steak', 2);

INSERT INTO TableDetails (TableDetailId, TableId, Material, Color)
VALUES
    ('770e8400-e29b-41d4-a716-446655440000', '550e8400-e29b-41d4-a716-446655440000', 'Wood', 'Brown'),
    ('770e8401-e29b-41d4-a716-446655440001', '550e8401-e29b-41d4-a716-446655440001', 'Metal', 'Gray'),
    ('770e8402-e29b-41d4-a716-446655440002', '550e8402-e29b-41d4-a716-446655440002', 'Glass', 'Transparent'),
    ('770e8403-e29b-41d4-a716-446655440003', '550e8403-e29b-41d4-a716-446655440003', 'Wood', 'Black'),
    ('770e8404-e29b-41d4-a716-446655440004', '550e8404-e29b-41d4-a716-446655440004', 'Marble', 'White');

INSERT INTO Menu (MenuId, MenuName, Price)
VALUES
    ('880e8400-e29b-41d4-a716-446655440000', 'Pasta', 12.99),
    ('880e8401-e29b-41d4-a716-446655440001', 'Pizza', 15.99),
    ('880e8402-e29b-41d4-a716-446655440002', 'Coffee', 4.50),
    ('880e8403-e29b-41d4-a716-446655440003', 'Salad', 9.99),
    ('880e8404-e29b-41d4-a716-446655440004', 'Steak', 25.00);

INSERT INTO TableOrderMenu (TableOrderId, MenuId)
VALUES
    ('660e8400-e29b-41d4-a716-446655440000', '880e8400-e29b-41d4-a716-446655440000'),
    ('660e8400-e29b-41d4-a716-446655440000', '880e8403-e29b-41d4-a716-446655440003'),
    ('660e8401-e29b-41d4-a716-446655440001', '880e8401-e29b-41d4-a716-446655440001'),
    ('660e8402-e29b-41d4-a716-446655440002', '880e8402-e29b-41d4-a716-446655440002'),
    ('660e8403-e29b-41d4-a716-446655440003', '880e8404-e29b-41d4-a716-446655440004');
    
    CREATE TABLE Users (
    Id VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT(UUID()),
    UserName VARCHAR(256) NULL,
    PasswordHash VARCHAR(256) NULL,
    RefreshToken VARCHAR(256) NULL
);
