create database contactDB;

create table contact(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Contact_name NVARCHAR(100) not null,
  Phoneno NVARCHAR(50) not null,
  Contact_address NVARCHAR(60) not null,
  Contact_group NVARCHAR(50) not null
);



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsertContact
	-- Add the parameters for the stored procedure here
  @Contact_name NVARCHAR(100),
  @Phoneno NVARCHAR(50) ,
  @Contact_address NVARCHAR(60),
  @Contact_group NVARCHAR(50) 
AS
BEGIN
	INSERT INTO contact (Contact_name, Phoneno, Contact_address, Contact_group)
    VALUES (@Contact_name, @Phoneno, @Contact_address, @Contact_group);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE FetchContacts
	@Id int
AS
BEGIN
	select * from contact ;
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE FetchContact
	@Id int
AS
BEGIN
	select * from contact where Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateContact
  @Id int,
  @Contact_name NVARCHAR(100),
  @Phoneno NVARCHAR(50) ,
  @Contact_address NVARCHAR(60),
  @Contact_group NVARCHAR(50) 
AS
BEGIN
	update contact set Contact_name = @Contact_name,Phoneno = @Phoneno,Contact_address =@Contact_address,@Contact_group =@Contact_group where Id =@id;
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteContact
  @Id int
AS
BEGIN
	Delete from contact where Id = @Id
END
GO