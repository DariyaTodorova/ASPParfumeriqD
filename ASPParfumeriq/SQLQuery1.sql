DELETE FROM Products;


INSERT INTO Categories (Name, RegisterOn)
SELECT N'Мъжки', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM Categories WHERE Name = N'Мъжки'
);

INSERT INTO Categories (Name, RegisterOn)
SELECT N'Дамски', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM Categories WHERE Name = N'Дамски'
);

INSERT INTO Categories (Name, RegisterOn)
SELECT N'Подаръчни комплекти', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM Categories WHERE Name = N'Подаръчни комплекти'
);


INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Луксозни', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Луксозни'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Спортни', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Спортни'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Дървесни', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Дървесни'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Флорални', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Флорални'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Амбров', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Амбров'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Гурме', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Гурме'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Мъжки комплект', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Мъжки комплект'
);

INSERT INTO TypeParfumes (Name, RegisterOn)
SELECT N'Дамски комплект', GETDATE()
WHERE NOT EXISTS
(
    SELECT 1 FROM TypeParfumes WHERE Name = N'Дамски комплект'
);


DECLARE @MenCategoryId INT =
(
    SELECT TOP 1 Id
    FROM Categories
    WHERE Name = N'Мъжки'
);

DECLARE @WomenCategoryId INT =
(
    SELECT TOP 1 Id
    FROM Categories
    WHERE Name = N'Дамски'
);

DECLARE @GiftCategoryId INT =
(
    SELECT TOP 1 Id
    FROM Categories
    WHERE Name = N'Подаръчни комплекти'
);

DECLARE @LuxuryId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Луксозни'
);

DECLARE @SportId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Спортни'
);

DECLARE @TreeId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Дървесни'
);

DECLARE @FloralId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Флорални'
);

DECLARE @AmbrovId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Амбров'
);

DECLARE @GurmetId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Гурме'
);

DECLARE @MenGiftId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Мъжки комплект'
);

DECLARE @WomenGiftId INT =
(
    SELECT TOP 1 Id
    FROM TypeParfumes
    WHERE Name = N'Дамски комплект'
);


INSERT INTO Products
(
    Name,
    CategoryId,
    Quantity,
    TypeParfumeId,
    PhotoUrl,
    Price,
    Description,
    RegisterOn
)
VALUES

(N'Dior Sauvage', @MenCategoryId, 10, @LuxuryId, N'/images/snimka2.jpg', 189, N'Свеж и дървесен аромат.', GETDATE()),
(N'Bleu de Chanel', @MenCategoryId, 8, @LuxuryId, N'/images/bleu.jpg', 210, N'Елегантен мъжки аромат.', GETDATE()),
(N'Gentleman Givenchy', @MenCategoryId, 7, @LuxuryId, N'/images/gentleman.jpg', 195, N'Стилен аромат.', GETDATE()),

(N'Armani Code', @MenCategoryId, 12, @SportId, N'/images/armani.jpg', 175, N'Модерен аромат.', GETDATE()),
(N'Stronger With You', @MenCategoryId, 9, @SportId, N'/images/stronger.jpg', 180, N'Силен мъжки аромат.', GETDATE()),
(N'Invictus', @MenCategoryId, 11, @SportId, N'/images/invictus.jpg', 165, N'Свеж спортен аромат.', GETDATE()),

(N'Yves Saint Laurent Myslf', @MenCategoryId, 8, @TreeId, N'/images/ysl.jpg', 220, N'Интензивен аромат.', GETDATE()),
(N'Lacoste Blanc', @MenCategoryId, 10, @TreeId, N'/images/lacoste.jpg', 145, N'Чист аромат.', GETDATE()),

(N'Good Girl', @WomenCategoryId, 7, @FloralId, N'/images/goodgirl.jpg', 199, N'Луксозен дамски аромат.', GETDATE()),
(N'Kylie', @WomenCategoryId, 10, @FloralId, N'/images/kylie.jpg', 145, N'Нежен аромат.', GETDATE()),
(N'Femme', @WomenCategoryId, 9, @FloralId, N'/images/femme.jpg', 155, N'Женствен аромат.', GETDATE()),

(N'Scandal', @WomenCategoryId, 9, @AmbrovId, N'/images/scandal.jpg', 185, N'Сладък аромат.', GETDATE()),
(N'Guerlain', @WomenCategoryId, 6, @AmbrovId, N'/images/guerlain.jpg', 205, N'Топъл аромат.', GETDATE()),
(N'Poison Girl', @WomenCategoryId, 8, @AmbrovId, N'/images/poison.jpg', 175, N'Силен аромат.', GETDATE()),

(N'Killian Love', @WomenCategoryId, 5, @GurmetId, N'/images/killian.jpg', 260, N'Гурме аромат.', GETDATE()),
(N'La Belle', @WomenCategoryId, 7, @GurmetId, N'/images/labelle.jpg', 190, N'Сладък аромат.', GETDATE()),
(N'Irresistible', @WomenCategoryId, 9, @GurmetId, N'/images/irresistible.jpg', 170, N'Нежен аромат.', GETDATE()),

(N'Комплект Dior Sauvage', @GiftCategoryId, 5, @MenGiftId, N'/images/diorset.jpg', 260, N'Луксозен комплект.', GETDATE()),
(N'Комплект Good Girl', @GiftCategoryId, 5, @WomenGiftId, N'/images/goodgirlset.jpg', 250, N'Луксозен комплект.', GETDATE());


SELECT * FROM Products;