SELECT * FROM Products

INSERT INTO Categories (Name, RegisterOn)
VALUES
(N'Мъжки', GETDATE()),
(N'Дамски', GETDATE()),
(N'Подаръчни комплекти', GETDATE());



INSERT INTO TypeParfumes (Name, RegisterOn)
VALUES
(N'Луксозни', GETDATE()),
(N'Спортни', GETDATE()),
(N'Дървесни', GETDATE()),
(N'Флорални', GETDATE()),
(N'Амбров', GETDATE()),
(N'Гурме', GETDATE()),
(N'Мъжки комплект', GETDATE()),
(N'Дамски комплект', GETDATE());








INSERT INTO Products
(Name, CategoryId, Quantity, TypeParfumeId, PhotoUrl, Price, Description, RegisterOn)

VALUES

-- МЪЖКИ ЛУКСОЗНИ

(
N'Dior Sauvage',
1,
10,
1,
'/images/mendior.jpg',
189,
N'Luxury men parfum.',
GETDATE()
),

(
N'Bleu de Chanel',
1,
10,
1,
'/images/bleu.jpg',
210,
N'Premium luxury parfum.',
GETDATE()
),

-- СПОРТНИ

(
N'Armani Code',
1,
10,
2,
'/images/armani.jpg',
175,
N'Sport parfum.',
GETDATE()
),

(
N'Invictus',
1,
10,
2,
'/images/invictus.jpg',
165,
N'Sport men parfum.',
GETDATE()
),

-- ДЪРВЕСНИ

(
N'Stronger With You',
1,
10,
3,
'/images/stronger.jpg',
199,
N'Darvesen parfum.',
GETDATE()
),

(
N'YSL Myslf',
1,
10,
3,
'/images/ysl.jpg',
220,
N'Luxury darvesen parfum.',
GETDATE()
),

-- ДАМСКИ ФЛОРАЛНИ

(
N'Good Girl',
2,
10,
4,
'/images/goodgirl.jpg',
199,
N'Luxury women parfum.',
GETDATE()
),

(
N'Kylie',
2,
10,
4,
'/images/kylie.jpg',
145,
N'Women luxury parfum.',
GETDATE()
),

-- АМБРОВИ

(
N'Poison Girl',
2,
10,
5,
'/images/poison.jpg',
175,
N'Ambrov women parfum.',
GETDATE()
),

(
N'Scandal',
2,
10,
5,
'/images/scandal.jpg',
185,
N'Luxury ambrov parfum.',
GETDATE()
),

-- ГУРМЕ

(
N'La Belle',
2,
10,
6,
'/images/labelle.jpg',
215,
N'Gurme parfum.',
GETDATE()
),

(
N'Killian Love',
2,
10,
6,
'/images/killian.jpg',
320,
N'Luxury gurme parfum.',
GETDATE()
),

-- КОМПЛЕКТИ

(
N'Комплект Dior Sauvage',
3,
5,
7,
'/images/diorset.jpg',
260,
N'Luxury men set.',
GETDATE()
),

(
N'Комплект Good Girl',
3,
5,
8,
'/images/cavali.jpg',
250,
N'Luxury women set.',
GETDATE()
);