IF NOT EXISTS (SELECT 1 FROM Information_schema.TABLES where TABLE_NAME = 'Usuario')
BEGIN
	Create table Usuario(
		Id int Identity(1,1) primary key, 
		Nome varchar(255) null,
		Data_Nasc datetime null,
		Telefone_Fixo varchar(20) null,
		Numero_Celular varchar(20) null,
		Email varchar(50) null,		
		EnderecoId int null,
		Foto_Usuario varbinary(max) null,
		GestorId int null,
		constraint FK_Usuario_Gestor foreign key (GestorId) references Usuario(Id)
	);
END

IF NOT EXISTS (SELECT 1 FROM Information_schema.TABLES where TABLE_NAME = 'Endereco')
BEGIN
	CREATE TABLE Endereco (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Nome_Rua NVARCHAR(255) NULL,
    Numero_Casa INT NULL,
    Complemento NVARCHAR(255) NULL,
    Bairro NVARCHAR(100) NULL,
    Cidade NVARCHAR(100) NULL,
    Estado NVARCHAR(50) NULL,
    Cep NVARCHAR(20) NULL,
    UsuarioId INT NULL,
    CONSTRAINT FK_Endereco_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
	);
END

IF EXISTS (SELECT 1 FROM Information_schema.TABLES where TABLE_NAME = 'Usuario' and TABLE_NAME = 'Endereco')
Begin
	alter table Usuario Add constraint FK_Usuario_Endereco foreign key (EnderecoId) references Endereco(Id);

	alter table Usuario add Senha varchar(250) null;

	alter table Usuario add Salt varchar(250) null;

	alter table Usuario add Primeiro_Acesso bit null;

	ALTER TABLE Usuario ADD CONSTRAINT UQ_Email UNIQUE (Email);
End

IF NOT EXISTS (SELECT 1 FROM Information_schema.TABLES where TABLE_NAME = 'Tarefa')
BEGIN
	Create table Tarefa(
		Id int Identity(1,1) primary key, 
		mensagem varchar(255) null,
		data_limite datetime null,		
		subordinadoId int null,
		constraint FK_Usuario_Subordinado foreign key (subordinadoId) references Usuario(Id)
	);
END
