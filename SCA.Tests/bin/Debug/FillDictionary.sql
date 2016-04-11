
	INSERT INTO [dbo].[ReadyToSellState] (Id, Code, Name, IsDeleted) VALUES (NEWID(), 1, N'Нет информации', 0)
	INSERT INTO [dbo].[ReadyToSellState] (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 2, N'Холодный', 0)
	INSERT INTO [dbo].[ReadyToSellState] (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 3, N'Теплый', 0)
	INSERT INTO [dbo].[ReadyToSellState] (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'Горячий', 0)

	INSERT INTO ContactType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 1, N'Бот', 0)
	INSERT INTO ContactType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 2, N'Потенциальный клиент', 0)
	INSERT INTO ContactType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 3, N'Клиент', 0)
	INSERT INTO ContactType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'Сотрудник', 0)

	INSERT INTO CompanyType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 1, N'Клиент', 0)
	INSERT INTO CompanyType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 2, N'Партнер', 0)
	INSERT INTO CompanyType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 3, N'Поставщик', 0)
	INSERT INTO CompanyType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'Другая компания', 0)
	INSERT INTO CompanyType (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 5, N'Наша компания', 0)

	INSERT INTO ContactStatus (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 1, N'Черновик', 0)
	INSERT INTO ContactStatus (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 2, N'Подтвержденный', 0)
	INSERT INTO ContactStatus (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 3, N'Требует подтверждения', 0)
	INSERT INTO ContactStatus (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'Архив', 0)

  INSERT INTO AgeDirection (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 1, N'10-15 лет', 0)
	INSERT INTO AgeDirection (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 2, N'15-20 лет', 0)
	INSERT INTO AgeDirection (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 3, N'20-25 лет', 0)
	INSERT INTO AgeDirection (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'25-30 лет', 0)
	INSERT INTO AgeDirection (Id, Code, Name, IsDeleted)  VALUES (NEWID(), 4, N'больше 30 лет', 0)