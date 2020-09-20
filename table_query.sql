USE Menu;

CREATE TABLE MenuItem(id INT PRIMARY KEY IDENTITY(1,1), 
					creation_date DATETIME DEFAULT SYSDATETIME() NOT NULL, 
					title VARCHAR(255) UNIQUE NOT NULL, 
					ingredients TEXT, 
					description VARCHAR(500), 
					price MONEY CHECK(price > 0), 
					grams INT CHECK(grams > 0),
					calories NUMERIC(5, 4),
					cooking_time INT CHECK(cooking_time > 0));