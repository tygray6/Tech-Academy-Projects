USE libraryManagement

CREATE TABLE book (
    bookId INT PRIMARY KEY NOT NULL,
    title VARCHAR(50) NOT NULL,
	FKpublisherName VARCHAR(50) FOREIGN KEY REFERENCES bookPublisher(publisherName)
);

	INSERT INTO book (bookId, title, FKpublisherName)
	VALUES
		(1, 'The Lost Tribe', 'Grange'),
		(2, 'Lie To Me', 'Mira Books'),
		(3, 'Fever', 'Atlantic Monthly Pres'),
		(4, 'The Child Finder', 'Harper Collins'),
		(5, 'Ill Stay', 'Kensington'),
		(6, 'Happiness', 'Henry Holt'),
		(7, 'The Tigers Daughter', 'Tor'),
		(8, 'Autonomous', 'Tor'),
		(9, 'The Girl Friend', 'Kensington'),
		(10, 'Seven Days Of Us', 'Berkley'),
		(11, 'Second Acts', 'Amberjack'),
		(12, 'The Blind', 'Park Row Books'),
		(13, 'The Dark Lake', 'Grand Central Publishing'),
		(14, 'Stay With Me', 'Alfred A Knopf'),
		(15, 'Sourdough', 'Farrar Straus and Giroux'),
		(16, 'The Gatekeepers', 'Harlequin Teen'),
		(17, 'The Sidekicks', 'Harlequin Teen'),
		(18, 'Everless', 'Harper Teen'),
		(19, 'Your One & Only', 'HMH Books for Young Readers'),
		(20, 'The House at 758', 'Amberjack');

CREATE TABLE bookAuthors (
    FK1bookId INT FOREIGN KEY REFERENCES book(bookId),
	author VARCHAR(50) NOT NULL
);

	INSERT INTO bookAuthors (FK1bookId, author)
	VALUES
		(1, 'Stephen King'),
		(2, 'James Patterson'),
		(3, 'John Grisham'),
		(4, 'Rick Paul'),
		(5, 'Jim Kense'),
		(6, 'Harper Fleen'),
		(7, 'Tory Pry'),
		(8, 'Tim Speen'),
		(9, 'Kenny Richin'),
		(10, 'Lyle Cullings'),
		(11, 'Amber Pleen'),
		(12, 'Parker Sloan'),
		(13, 'Gerry Plow'),
		(14, 'Allan Parks'),
		(15, 'Jennifer Kurtz'),
		(16, 'Jim Smith'),
		(17, 'Amy Marie'),
		(18, 'Ashley Lee'),
		(19, 'Gary Bryce'),
		(20, 'Paul Mitch');

CREATE TABLE bookCopies (
    FKbookId INT FOREIGN KEY REFERENCES book(bookId),
	FK1branchId INT FOREIGN KEY REFERENCES libraryBranch(branchId),
	numOfCopies INT NOT NULL
);

	INSERT INTO bookCopies (FKbookId, FK1branchId, numOfCopies)
	VALUES
		(1, 632, 18),
		(2, 632, 10),
		(3, 632, 11),
		(4, 632, 14),
		(5, 632, 10),
		(6, 632, 11),
		(7, 632, 12),
		(8, 632, 13),
		(9, 632, 20),
		(10, 632, 18),
		(1, 329, 21),
		(12, 329, 14),
		(13, 329, 15),
		(14, 329, 17),
		(15, 329, 17),
		(16, 329, 16),
		(17, 329, 10),
		(18, 329, 21),
		(19, 329, 22),
		(20, 329, 14),
		(3, 410, 21),
		(7, 410, 14),
		(1, 410, 15),
		(20, 410, 17),
		(12, 410, 17),
		(16, 410, 16),
		(8, 410, 10),
		(9, 410, 21),
		(5, 410, 22),
		(2, 410, 14),
		(11, 118, 21),
		(12, 118, 14),
		(13, 118, 15),
		(14, 118, 17),
		(15, 118, 17),
		(16, 118, 16),
		(17, 118, 10),
		(18, 118, 21),
		(19, 118, 22),
		(20, 118, 14),
		(9, 286, 21),
		(6, 286, 14),
		(5, 286, 15),
		(1, 286, 17),
		(2, 286, 17),
		(14, 286, 16),
		(7, 286, 10),
		(15, 286, 21),
		(19, 286, 22),
		(20, 286, 14);

CREATE TABLE libraryBranch (
    branchId INT PRIMARY KEY NOT NULL,
    branchName VARCHAR(50) NOT NULL,
	branchAddress VARCHAR(50) NOT NULL
);

	INSERT INTO libraryBranch (branchId, branchName, branchAddress)
	VALUES
		(118, 'Archbold Public Library', '567 Park St. Archbold, OH'),
		(410, 'Defiance Public Library', '673 Dodge St. Defiance, OH'),
		(632, 'Central Library', '2134 Maumee St. Toledo, OH'),
		(286, 'South Street Library', '77 Beiling Ct. Cleveland, OH'),
		(329, 'Sharpstown Library', '7531 Brawling St. Columbus, OH');

CREATE TABLE bookLoans (
	FK2bookId INT FOREIGN KEY REFERENCES book(bookId),
    FKbranchId INT FOREIGN KEY REFERENCES libraryBranch(branchId),
	FKcardNo INT FOREIGN KEY REFERENCES borrower(cardNo),
    dateOut VARCHAR(50) NOT NULL,
	dueDate VARCHAR(50) NOT NULL
);

	INSERT INTO bookLoans (FK2bookId, FKbranchId, FKcardNo, dateOut, dueDate)
	VALUES
		(1, 118, 22510, '4/11/17', '5/11/17'),
		(2, 410, 22510, '4/11/17', '5/11/17'),
		(7, 410, 1267, '5/3/17', '6/3/17'),
		(3, 632, 59087, '5/5/17', '6/5/17'),
		(12, 329, 22510, '4/11/17', '5/11/17'),
		(19, 329, 75365, '7/8/17', '8/8/17'),
		(20, 410, 22510, '4/11/17', '5/11/17'),
		(16, 329, 75365, '3/2/17', '4/2/17'),
		(15, 118, 12876, '11/12/17', '12/12/17'),
		(8, 632, 75365, '3/2/17', '4/2/17'),
		(6, 329, 22510, '4/11/17', '5/11/17'),
		(4, 329, 75365, '3/7/17', '4/7/17'),
		(6, 632, 75365, '10/15/17', '11/15/17'),
		(13, 118, 22510, '4/11/17', '5/11/17'),
		(14, 329, 9567, '12/29/17', '01/29/18'),
		(16, 410, 12876, '11/2/17', '12/2/17'),
		(20, 118, 12876, '2/5/17', '3/5/17'),
		(2, 632, 75365, '4/8/17', '5/8/17'),
		(6, 286, 0962, '2/3/17', '3/3/17'),
		(18, 286, 6897, '1/2/17', '2/2/17'),
		(19, 286, 0962, '2/3/17', '3/3/17'),
		(12, 410, 6897, '9/4/17', '10/4/17'),
		(10, 329, 6897, '5/3/17', '6/3/17'),
		(1, 286, 3764, '10/30/17', '11/30/17'),
		(2, 329, 12876, '8/2/17', '9/2/17'),
		(3, 118, 3765, '6/18/17', '7/18/17'),
		(4, 118, 0962, '2/3/17', '3/3/17'),
		(5, 329, 12876, '1/12/17', '2/12/17'),
		(7, 329, 59087, '12/1/17', '01/1/17'),
		(15, 410, 3675, '12/19/17', '01/19/18'),
		(18, 329, 3675, '11/11/17', '12/11/17'),
		(16, 286, 6897, '10/5/17', '11/5/17'),
		(13, 286, 3675, '12/20/17', '01/20/18'),
		(11, 329, 0962, '2/3/17', '3/3/17'),
		(10, 118, 59087, '12/1/17', '01/1/17'),
		(17, 118, 3764, '10/30/17', '11/30/17'),
		(18, 410, 3764, '10/30/17', '11/30/17'),
		(15, 632, 3765, '6/18/17', '7/18/17'),
		(13, 410, 59087, '12/1/17', '01/1/17'),
		(12, 118, 0962, '2/3/17', '3/3/17'),
		(11, 410, 3765, '6/18/17', '7/18/17'),
		(10, 410, 3765, '6/18/17', '7/18/17'),
		(3, 286, 3764, '10/30/17', '11/30/17'),
		(8, 410, 59087, '12/1/17', '01/1/17'),
		(9, 329, 0962, '2/3/17', '3/3/17'),
		(6, 118, 9567, '12/29/17', '01/29/18'),
		(7, 286, 3764, '10/30/17', '11/30/17'),
		(2, 286, 3764, '10/15/17', '11/15/17'),
		(8, 118, 9567, '12/29/17', '01/29/18'),
		(2, 118, 9567, '12/29/17', '01/29/18');

CREATE TABLE bookPublisher (
	publisherName VARCHAR(50) PRIMARY KEY NOT NULL,
	publisherAddress VARCHAR(50) NOT NULL,
	publisherPhone VARCHAR(50) NOT NULL
);

	INSERT INTO bookPublisher (publisherName, publisherAddress, publisherPhone)
	VALUES
		('Grange', '11 Park St. Sylvania, OH', '427-324-1299'),
		('Mira Books', '29 Hayes Ave. Fremont, OH', '438-673-2789'),
		('Atlantic Monthly Pres', '398 Strawberry Lane Hilltop, OH', '293-749-5630'),
		('Harper Collins', '239 Woodley Ave. Toledo, OH', '283-854-8530'),
		('Kensington', '876 Johnson St. Sylvania, OH', '483-753-8765'),
		('Henry Holt', '398 Silver St. Wauseon, OH', '295-198-2398'),
		('Tor', '333 Staple St. Archbold, OH', '390-432-1298'),
		('Berkley', '749 Park Ave. Toledo, OH', '784-789-3400'),
		('Amberjack', '320 Harp St. Defiance, OH', '210-540-3245'),
		('Park Row Books', '7308 County Line Rd. Fayette, OH', '219-340-3212'),
		('Grand Central Publishing', '637 Peanut Ave. Sylvania, OH', '439-786-0986'),
		('Alfred A Knopf', '129 Monroe St. Toledo, OH', '397-439-7548'),
		('Farrar Straus and Giroux', '734 Sylvania Ave. Maumee, OH', '439-548-2312'),
		('Harlequin Teen', '499 Alexis Rd. Perrysburg, OH', '329-548-4352'),
		('Harper Teen', '321 Central Ave. Toledo, OH', '430-987-4071'),
		('HMH Books for Young Readers', '120 McCord Ave. Ottawa, OH', '987-349-7645');

CREATE TABLE borrower (
	cardNo INT PRIMARY KEY NOT NULL,
	borrowerName VARCHAR(50) NOT NULL,
	borrowerAddress VARCHAR(50) NOT NULL,
	borrowerPhone VARCHAR(50) NOT NULL
);

	INSERT INTO borrower (cardNo, borrowerName, borrowerAddress, borrowerPhone)
	VALUES
		(22510, 'Quinn Avery', '11 Park St. Sylvania, OH', '427-324-1299'),
		(9567, 'Reese Emery', '29 Hayes Ave. Fremont, OH', '438-673-2789'),
		(3764, 'David Lee', '398 Strawberry Lane Hilltop, OH', '293-749-5630'),
		(0962, 'Chris Patacca', '239 Woodley Ave. Toledo, OH', '283-854-8530'),
		(3765, 'Scott Moyer', '876 Johnson St. Sylvania, OH', '483-753-8765'),
		(59087, 'Ryan Hill', '398 Silver St. Wauseon, OH', '295-198-2398'),
		(1267, 'Greg Law', '333 Staple St. Archbold, OH', '390-432-1298'),
		(3675, 'Olivia Brink', '749 Park Ave. Toledo, OH', '784-789-3400'),
		(6897, 'Sarah Gray', '320 Harp St. Defiance, OH', '210-540-3245'),
		(12876, 'Madyson Austin', '7308 County Line Rd. Fayette, OH', '219-340-3212'),
		(95637, 'Tyler Gray', '5489 Acres Rd. Sylvania, OH', '439-827-5987'),
		(75365, 'Brady Lee', '637 Peanut Ave. Sylvania, OH', '439-786-0986');

DROP TABLE borrower
DROP TABLE bookPublisher
DROP TABLE bookLoans
DROP TABLE libraryBranch
DROP TABLE bookCopies
DROP TABLE bookAuthors
DROP TABLE book

SELECT * FROM book
SELECT * FROM borrower
SELECT * FROM bookPublisher
SELECT * FROM bookLoans
SELECT * FROM bookCopies
SELECT * FROM bookAuthors
SELECT * FROM libraryBranch

USE libraryManagement

/* How many copies of "The Lost Tribe" are owned by "Sharpstown" */

CREATE PROC findNumOfCopies

	@branch varchar(50),
	@book varchar(50)

AS
	BEGIN
	SELECT
		title,
		branchName,
		numOfCopies
	FROM bookCopies
		INNER JOIN book ON book.bookId = bookCopies.FKbookId
		INNER JOIN libraryBranch ON libraryBranch.branchId = bookCopies.FK1branchId
	WHERE book.title LIKE @book
		AND libraryBranch.branchName LIKE @branch
	END

EXEC [dbo].[findNumOfCopies]
	@book = 'The Lost %',
	@branch = 'Sharp%'


/* How many copies of "The Lost Tribe" are owned by each library branch */

CREATE PROC findTotalCopies

	@book varchar(50)

AS
	BEGIN
	SELECT
		branchName,
		numOfCopies
	FROM bookCopies
		INNER JOIN book ON book.bookId = bookCopies.FKbookId
		INNER JOIN libraryBranch ON libraryBranch.branchId = bookCopies.FK1branchId
	WHERE book.title LIKE @book
	END

EXEC [dbo].[findTotalCopies]
	@book = 'The Lost Tribe'

/* Retrieve the names of all borrowers who do not have any books checked out */

CREATE PROC borrowersWithNoBooks

AS
	BEGIN
	SELECT
		borrowerName as 'Name:',
		borrowerAddress as 'Address:',
		borrowerPhone as 'Phone:'
	FROM bookLoans
		INNER JOIN book ON book.bookId = bookLoans.FK2bookId
		FULL OUTER JOIN borrower ON borrower.cardNo = bookLoans.FKcardNo
	WHERE bookLoans.FKcardNo IS NULL
	END

EXEC [dbo].[borrowersWithNoBooks]

/* For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, retrieve the book title, the borrower's name, and the borrower's address. */


CREATE PROC dueToday

	@date VARCHAR(10),
	@branch VARCHAR(20)

AS
	BEGIN
	SELECT
		title as 'Book:',
		borrowerName as 'Name:',
		borrowerAddress as 'Address:',
		dueDate as 'Date Due:'
	FROM bookLoans
		INNER JOIN book ON book.bookId = bookLoans.FK2bookId
		INNER JOIN borrower ON borrower.cardNo = bookLoans.FKcardNo
		INNER JOIN libraryBranch ON libraryBranch.branchId = bookLoans.FKbranchId
	WHERE dueDate LIKE @date AND
		  branchName LIKE @branch
	END

EXEC [dbo].[dueToday]
	@branch = 'Sharpstown%',
	@date = '8/8/17' /* I chose to do this value as an enter date instead of auto set to run as todays date because by the time you would run it the values wouldn't work because
						the day would no longer be today. */


/* For each library branch, retrieve the branch name and the total number of books loaned out from that branch. */

CREATE PROC booksOnLoan

AS

	BEGIN
	SELECT
		branchName as 'Branch:',
		COUNT (FK2bookId) as 'Books on Loan:'
	FROM bookLoans
		INNER JOIN libraryBranch ON libraryBranch.branchId = bookLoans.FKbranchId
	WHERE FK2bookId >= 1
	GROUP BY branchName
	END

EXEC [dbo].[booksOnLoan]


/* Retrieve the names, addresses, and number of books checked out for all borrowers who have more than five books checked out. */

CREATE PROC moreThanFive

AS

	BEGIN
	SELECT
		borrowerName as 'Name:',
		borrowerAddress as 'Address:',
		COUNT (FKcardNo) as 'Number of Books:'
	FROM bookLoans
		INNER JOIN borrower ON borrower.cardNo = bookLoans.FKcardNo
	GROUP BY borrowerName, borrowerAddress
	HAVING COUNT (*) >= 5;
	END

EXEC [dbo].[moreThanFive]


/* For each book authored (or co-authored) by "Stephen King", retrieve the title and the number of copies owned by the library branch whose name is "Central". */

CREATE PROC stephenKing

AS

	BEGIN
	SELECT
		title as 'Title:',
		author as 'Author:',
		numOfCopies as 'Copies:'
	FROM bookCopies
		INNER JOIN book ON book.bookId = bookCopies.FKbookId
		INNER JOIN bookAuthors ON bookAuthors.FK1bookId = bookCopies.FKbookId
		INNER JOIN libraryBranch ON libraryBranch.branchId = bookCopies.FK1branchId
	WHERE author = 'Stephen King' AND branchName = 'Central Library'
	END

EXEC [dbo].[stephenKing]
		


		
