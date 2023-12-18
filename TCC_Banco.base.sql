drop database hot_rolls_club
use master

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'hot_rolls_club')
    DROP DATABASE hot_rolls_club
go
CREATE DATABASE hot_rolls_club
go
USE hot_rolls_club
go
-- Criação da tabela Cliente
CREATE TABLE Cliente (
  cpf VARCHAR(11) NOT NULL PRIMARY KEY,
  nome VARCHAR(50) NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  data_nascimento DATE,
  sexo CHAR(1),
  senha VARCHAR(MAX) NOT NULL,
  img_cliente VARBINARY(MAX)
);
go
-- Criação da tabela Funcionario
CREATE TABLE Funcionario (
  id_funcionario INT IDENTITY NOT NULL PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  cargo VARCHAR(50) NOT NULL,
  turno VARCHAR(30) NOT NULL,
  salario DECIMAL(10, 2) NOT NULL,
  endereco VARCHAR(100) NOT NULL,
  CEP VARCHAR(10) NOT NULL,
  cpf VARCHAR(11) NOT NULL UNIQUE,
  data_nascimento DATE NOT NULL,
  sexo CHAR(1) NOT NULL,
  senha VARCHAR(8) NOT NULL,
  img_func VARBINARY(MAX),
  data_contratacao DATE NOT NULL,
  ativo BIT NOT NULL DEFAULT 1
);
go
-- Criação da tabela Mesa
CREATE TABLE Mesa (
numero_mesa INT PRIMARY KEY,
status_mesa VARCHAR(15) not null default 'Disponível',
capacidade_mesa INT NOT NULL
);
go
-- Criação da tabela Pedido
CREATE TABLE Pedido (
  id_pedido INT IDENTITY NOT NULL PRIMARY KEY,
  cpf VARCHAR(11) NULL,
  id_funcionario INT NULL,
  data_pedido DATETIME NOT NULL,
  valor_total DECIMAL(10, 2) NOT NULL,
  formapagamento VARCHAR(100) NOT NULL,
  numero_mesa INT NOT NULL,
  FOREIGN KEY (cpf) REFERENCES Cliente (cpf),
  FOREIGN KEY (id_funcionario) REFERENCES Funcionario (id_funcionario),
  FOREIGN KEY (numero_mesa) REFERENCES Mesa (numero_mesa)
);
go
-- Criação da tabela StatusPedido
CREATE TABLE StatusPedido (
id_pedido INT NOT NULL,
id_funcionario INT,
status_pedido VARCHAR(50) NOT NULL default 'Em Preparo',
PRIMARY KEY (id_pedido),
FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido) ON DELETE CASCADE,
FOREIGN KEY (id_funcionario) REFERENCES Funcionario(id_funcionario)
);
go
-- Criação da tabela CategoriaProduto
CREATE TABLE CategoriaProduto (
  id_categoriaprod INT IDENTITY NOT NULL PRIMARY KEY,
  nome_categoria VARCHAR(50) NOT NULL,
  descricao VARCHAR(200)
);
go
-- Criação da tabela Produtos
CREATE TABLE Produtos (
  id_produto INT IDENTITY NOT NULL PRIMARY KEY,
  nome_produto VARCHAR(50) NOT NULL,
  descricao VARCHAR(200) NOT NULL,
  id_categoriaprod INT NOT NULL,
  preco DECIMAL(10,2) NOT NULL,
  unidade_medida VARCHAR(10) NOT NULL,
  img_prato VARBINARY(MAX)
  FOREIGN KEY (id_categoriaprod) REFERENCES CategoriaProduto (id_categoriaprod),
  ativo BIT NOT NULL DEFAULT 1
);
go
-- Criação da tabela Fornecedor
CREATE TABLE Fornecedor (
  id_fornecedor INT IDENTITY NOT NULL PRIMARY KEY,
  nome_fornecedor VARCHAR(100) NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  endereco VARCHAR(100) NOT NULL,
  ativo BIT NOT NULL DEFAULT 1
);
go
-- Criação da tabela Insumos
CREATE TABLE Insumos (
  id_insumo INT IDENTITY NOT NULL PRIMARY KEY,
  nome_insumo VARCHAR(50) NOT NULL,
  descricao VARCHAR(200) NOT NULL,
  id_fornecedor INT NOT NULL,
  estoque NUMERIC(10,2) NOT NULL,
  unidade_medida VARCHAR(20),
  data_entrada DATE NOT NULL,
  data_validade DATE NOT NULL,
  FOREIGN KEY (id_fornecedor) REFERENCES Fornecedor(id_fornecedor),
  ativo BIT NOT NULL DEFAULT 1
);
go
-- Criação da tabela InsumosProduto
CREATE TABLE InsumosProduto (
  id_produto INT NOT NULL,
  id_insumo INT NOT NULL,
  quantidade_insumo NUMERIC(10,2) NOT NULL,
  unidade_medida VARCHAR(20),
  PRIMARY KEY (id_produto, id_insumo),
  FOREIGN KEY (id_produto) REFERENCES Produtos (id_produto),
  FOREIGN KEY (id_insumo) REFERENCES Insumos (id_insumo)
);
go
-- Criação da tabela Reserva
CREATE TABLE Reserva (
   id_reserva INT IDENTITY PRIMARY KEY,
   cpf VARCHAR(11) NOT NULL,
   numero_mesa INT NOT NULL,  
   data_reserva DATETIME NOT NULL,
   quantidade_pessoas INT NOT NULL,
   ativo BIT NOT NULL DEFAULT 1,
   FOREIGN KEY (cpf) REFERENCES Cliente(cpf),
   FOREIGN KEY (numero_mesa) REFERENCES Mesa(numero_mesa)
);
go
-- Criação da tabela Avaliação
CREATE TABLE Avaliacao (
   id_avaliacao INT IDENTITY PRIMARY KEY,
   cpf VARCHAR(11) NOT NULL,
   id_produto INT NOT NULL,
   estrelas INT NOT NULL,
   comentario_avaliacao VARCHAR(255),
   data_avaliacao DATETIME NOT NULL,
   FOREIGN KEY (id_produto) REFERENCES Produtos(id_produto),
   FOREIGN KEY (cpf) REFERENCES Cliente(cpf)
);
go
-- Criação da tabela DetalhesPedido
CREATE TABLE DetalhesPedido (
   id_pedido INT NOT NULL,
   id_produto INT NOT NULL,
   valor_unitario Decimal(10,2) NOT NULL,
   quantidade_produto INT NOT NULL,
   PRIMARY KEY (id_pedido, id_produto),
   FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido) ON DELETE CASCADE,
   FOREIGN KEY (id_produto) REFERENCES Produtos(id_produto)
);
CREATE TABLE Favorito(
cpf VARCHAR(11) NOT NULL,
id_produto INT NOT NULL,
PRIMARY KEY (id_produto),
FOREIGN KEY (cpf) REFERENCES Cliente(cpf),
FOREIGN KEY (id_produto) REFERENCES Produtos(id_produto)
);
go
	CREATE  TYPE dbo.ProdutosType AS TABLE
(
    id_produto INT,
    quantidade_produto INT
)
go
---------------------------CLIENTES---------------------------------------------------------------------------------------------------------------
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('12345678900', 'Maria da Silva', '(11) 99999-9999', 'maria.silva@gmail.com', '1990-01-01', 'F', '12345678');
go
---------------------------FUNCIONARIOS-------------------------------------------------------------------------------------------------------------------------------
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Admin', '(00) 00000-0000', 'admin@gmail.com', 'Administrador', 'Noturno', 2000.00, 'Rua A, 123', '01000-000', '00000000000', '1995-05-10', 'M', '12345678', '2023-01-01');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('João Souza', '(11) 98888-8888', 'joao.souza@gmail.com', 'Atendente', 'Noturno', 2000.00, 'Rua A, 123', '01000-000', '11122233344', '1995-05-10', 'M', '12345678', '2022-01-01');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Raphael', '(11) 98888-8888', 'rapha.rapha@gmail.com', 'Atendente', 'Noturno', 2000.00, 'Rua A, 123', '01000-000', '11122233345', '1995-05-10', 'M', '12345678', '2022-01-01');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Maria Silva', '(11) 97777-7777', 'maria.silva@gmail.com', 'Cozinheiro', 'Noturno', 2500.00, 'Rua B, 456', '02000-000', '22233344455', '1980-08-15', 'F', '87654321', '2022-02-15');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Carlos Oliveira', '(11) 96666-6666', 'carlos.oliveira@gmail.com', 'Administrador', 'Diurno', 4000.00, 'Rua C, 789', '03000-000', '33344455566', '1990-03-20', 'M', '13579246', '2022-03-10');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Ana Santos', '(11) 95555-5555', 'ana.santos@gmail.com', 'Administrador', 'Diurno', 4000.00, 'Rua D, 101', '04000-000', '44455566677', '1988-11-25', 'F', '98765432', '2022-04-05');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Roberto Lima', '(11) 94444-4444', 'roberto.lima@gmail.com', 'Atendente', 'Diurno', 2000.00, 'Rua E, 789', '05000-000', '55566677788', '1982-07-18', 'M', '11223344', '2022-05-20');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Juliana Pereira', '(11) 93333-3333', 'juliana.pereira@gmail.com', 'Atendente', 'Noturno', 2000.00, 'Rua F, 234', '06000-000', '66677788899', '1985-12-08', 'F', '99887766', '2022-06-15');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Ricardo Costa', '(11) 92222-2222', 'ricardo.costa@gmail.com', 'Cozinheiro', 'Noturno', 2500.00, 'Rua G, 567', '07000-000', '77788899900', '1993-04-30', 'M', '55443322', '2022-07-10');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Fernanda Martins', '(11) 91111-1111', 'fernanda.martins@gmail.com', 'Administrador', 'Diurno', 4000.00, 'Rua H, 890', '08000-000', '88899900011', '1998-09-22', 'F', '11223355', '2022-08-05');
go
INSERT INTO Funcionario (nome, telefone, email, cargo, turno, salario, endereco, CEP, cpf, data_nascimento, sexo, senha, data_contratacao)
VALUES ('Gustavo Oliveira', '(11) 90000-0000', 'gustavo.oliveira@gmail.com', 'Atendente', 'Noturno', 2000.00, 'Rua I, 111', '09000-000', '99900011122', '1996-01-12', 'M', '33445566', '2022-09-18');
go

-----------------------------MESAS-----------------------------------------------------------------------------------------
INSERT INTO Mesa (numero_mesa, capacidade_mesa) VALUES 
(1, 4),(2, 6),(3, 2),(4, 8),(5, 4),(6, 2),
(7, 6),(8, 4),(9, 2),(10, 6),(11, 4),(12, 2),
(13, 8),(14, 4),(15, 2),(16, 6),(17, 4),(18, 2)
go
--------------------------FORNECEDORES--------------------------------------------------------------------------------------
INSERT INTO Fornecedor (nome_fornecedor, telefone, email, endereco)
VALUES ('Fornecedor A', '(11) 1111-1111', 'fornecedora@teste.com', 'Rua A, 123');
go
INSERT INTO Fornecedor (nome_fornecedor, telefone, email, endereco)
VALUES ('Fornecedor B', '(22) 2222-2222', 'fornecedorb@teste.com', 'Rua B, 456');
go
-----------------------CATEGORIAS PRODUTOS----------------------------------------------------------------------------------
INSERT INTO CategoriaProduto (nome_categoria, descricao)
VALUES
('Sushi', 'Pequenos rolos de arroz com recheios variados, envolvidos em algas marinhas'),
('Sashimi', 'Fatias finas de peixe ou frutos do mar crus, servidos com molhos especiais'),
('Tempurá', 'Pedacinhos de legumes, frutos do mar ou carne empanados e fritos'),
('Yakissoba', 'Macarrão frito com legumes, carne e molho especial'),
('Temaki', 'Cone de alga recheado com arroz, peixe e vegetais.'),
('Nigiri', 'Bolinhas de arroz com um pedaço de peixe, fruto do mar ou ovo em cima.'),
('Robata', 'Espetinhos de carne, frutos do mar ou legumes grelhados em carvão vegetal'),
('Bebidas', 'Acompanhamento'),
('Sobremesas', 'Sobremesa')
-------------------------------Produtos---------------------------------------------------------------------------------------
--1
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida)
VALUES ('Hot Roll', 'Sushi roll recheado com salmão, cream cheese, pepino', 1, 12.99, '8 unidades');
go
--2
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida)
VALUES ('Temaki', 'Enrolado de alga recheado com arroz, peixe, legumes e molho especial', 5, 21.99, 'unidade');
go
--3
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida)
VALUES ('Robata', 'Espetinho grelhado com diversos tipos de carnes e legumes', 7, 14.99, 'unidade');
go
--4
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida)
VALUES ('Yakisoba Tradicional', 'Macarrão frito com legumes, carne ou frango e molho especial', 4, 24.99, 'unidade');
-- Inserir bebida 1
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Cerveja', 'Cerveja gelada de marca famosa', 8, 10.99, 'Unidade', NULL);

-- Inserir bebida 2
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Refrigerante', 'Refrigerante de cola', 8, 5.99, 'Unidade', NULL);

-- Inserir bebida 3
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Água Mineral', 'Água mineral sem gás', 8, 2.49, 'Unidade', NULL);

-------------------------------Insumos----------------------------------------------------------------------------------------
--1
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Arroz', 'Arroz japonês', 1, 100000, 'gramas', '2023-02-01', '2023-06-30');
go
--2
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Alga Nori', 'Alga seca para enrolar o sushi', 2, 5000, 'folhas', '2023-02-01', '2023-12-31');
go
--3
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Salmão', 'Salmão fresco para sushi', 2, 50000, 'gramas', '2023-02-01', '2023-06-15');
go
--4
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Pepino', 'Pepino fresco para sushi', 1, 50000, 'unidade', '2023-02-01', '2023-06-20');
go
--5
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Cenoura', 'Cenoura fresca para sushi', 2, 50000, 'unidade', '2023-02-01', '2023-06-25');
go
--6
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Camarão', 'Camarão fresco para sushi', 1, 50000, 'gramas', '2023-02-01', '2023-06-22');
go
--7
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Macarrão', 'Macarrão para yakisoba', 1, 50000, 'gramas', '2023-02-01', '2023-06-30');
go
--8
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Carne de Porco', 'Carne de porco para yakisoba', 2, 30000, 'gramas', GETDATE(), '2023-06-15');
go
--9 
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Repolho', 'Repolho picado para yakisoba', 2, 20000, 'gramas', '2023-02-01', '2023-06-20');
go
--10
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Brócolis', 'Brócolis para yakisoba', 1, 10000, 'unidade', '2023-02-01', '2023-06-22');
go
--11
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Frango', 'Pedacinhos de frango para robata', 2, 30000, 'gramas', GETDATE(), '2023-06-15');
go
--12
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Carne', 'Pedacinhos de carne bovina para robata', 1, 30000, 'gramas', GETDATE(), '2023-06-15');
go
--13
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Palitos de Bambu', 'Palitos de bambu para espetinhos', 2, 50000, 'unidades', GETDATE(), '2023-12-31');
go
--14
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Cebola', 'Cebola', 1, 50000, 'unidade', GETDATE(), '2023-06-25');
go
--15
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Pimentão', 'Pimentão cortado', 1, 10000, 'unidade', GETDATE(), '2023-06-18');
go
--16
INSERT INTO Insumos (nome_insumo, descricao, id_fornecedor, estoque, unidade_medida, data_entrada, data_validade)
VALUES ('Cream Cheese', 'Cream cheese', 2, 50000, 'gramas', GETDATE(), '2023-12-31');


-- Inserir prato de Sushi
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Sushi Misto', 'Variedade de sushis com salmão, atum e camarão', 1, 29.99, 'Porção', NULL);

-- Associar insumos ao prato de Sushi
-- Arroz
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (8, 1, 300, 'gramas');

-- Alga Nori
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (8, 2, 3, 'folhas');

-- Salmão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (8, 3, 200, 'gramas');

-- Pepino
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (8, 4, 50, 'unidade');

-- Inserir prato de Yakisoba
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Yakisoba de Frango', 'Macarrão frito com pedaços de frango e legumes', 4, 15.99, 'Porção', NULL);

-- Associar insumos ao prato de Yakisoba
-- Macarrão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (9, 7, 200, 'gramas');

-- Carne de Porco
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (9, 8, 100, 'gramas');

-- Repolho
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (9, 9, 50, 'gramas');

-- Brócolis
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (9, 10, 20, 'unidade');


-- Inserir prato de Sashimi
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Sashimi de Salmão', 'Salmão fresco cortado em fatias finas', 2, 24.99, 'Porção', NULL);

-- Associar insumos ao prato de Sashimi
-- Salmão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (10, 3, 150, 'gramas');

-- Inserir prato de Tempurá
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Tempurá de Camarão', 'Camarões empanados e fritos', 3, 18.99, 'Porção', NULL);

-- Associar insumos ao prato de Tempurá
-- Camarão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (11, 6, 100, 'gramas');

-- Inserir prato de Robata
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Robata de Frango', 'Espetinhos de frango grelhados', 7, 12.99, 'Porção', NULL);

-- Associar insumos ao prato de Robata
-- Frango
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (12, 11, 150, 'gramas');

-- Inserir prato de Teriyaki
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Frango Teriyaki', 'Frango grelhado com molho teriyaki', 4, 14.99, 'Porção', NULL);

-- Associar insumos ao prato de Teriyaki
-- Frango
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (13, 11, 100, 'gramas');

-- Inserir prato de Nigiri Sushi
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Nigiri Sushi de Salmão', 'Salmão fresco sobre arroz temperado', 6, 6.99, 'Unidade', NULL);

-- Associar insumos ao prato de Nigiri Sushi
-- Salmão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (14, 3, 15, 'gramas');

-- Arroz
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (14, 1, 50, 'gramas');

-- Inserir prato de Temaki
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Temaki de Atum', 'Atum fresco, arroz e outros ingredientes enrolados em alga', 5, 9.99, 'Unidade', NULL);

-- Associar insumos ao prato de Temaki
-- Atum
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (15, 3, 20, 'gramas');

-- Alga Nori
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (15, 2, 1, 'folhas');

-- Arroz
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (15, 1, 50, 'gramas');

-- Inserir prato de Yakisoba
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Yakisoba de Legumes', 'Macarrão frito com legumes e molho especial', 4, 18.99, 'Porção', NULL);

-- Associar insumos ao prato de Yakisoba
-- Macarrão
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (16, 7, 200, 'gramas');

-- Repolho
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (16, 9, 100, 'gramas');

-- Cenoura
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES (16, 5, 50, 'gramas');

-----------------------------------------Insumos Produtos------------------------------------------------------------------
-------FAZER HOT ROLL---------
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES
    -- Arroz para Sushi
    (1, 1, 50, 'gramas'),
    -- Nori (Alga Marinha)
    (1, 2, 1, 'folha'),
    -- Salmão
    (1, 3, 50, 'gramas'),
    -- Cream Cheese
    (1, 16, 20, 'gramas'),
    -- Pepino
    (1, 4, 1, 'unidade')
go
-------FAZER YAKISOBA------------
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES
    -- Insumo: Macarrão para Yakisoba
    (4, 7, 150, 'gramas'),
    -- Insumo: Carne (ex: Carne Bovina)
    (4, 12, 100, 'gramas'),
    -- Insumo: Cebola
    (4, 14, 1, 'unidade'),
    -- Insumo: Pimentão
    (4, 15, 1, 'unidade'),
    -- Insumo: Repolho
    (4, 9, 100, 'gramas'),
    -- Insumo: Cenoura
    (4, 5, 1, 'unidade')
go
------FAZER ROBATA---------------
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES
    -- Insumo: Frango
    (3, 11, 100, 'gramas'),
    -- Insumo: Carne 
    (3, 12, 100, 'gramas'),
    -- Insumo: Legumes (Cebola, Pimentão)
    (3, 15, 1, 'unidade'),
    (3, 14, 1, 'unidade'),
    -- Insumo: Palitos de Bambu
    (3, 13, 1, 'unidades');
go
----FAZER TEMAKI------------
INSERT INTO InsumosProduto (id_produto, id_insumo, quantidade_insumo, unidade_medida)
VALUES
    -- Insumo: Alga Nori
    (2, 2, 1, 'folha'),
    -- Insumo: Arroz para Sushi
    (2, 1, 80, 'gramas'),
    -- Insumo: Peixe (ex: Salmão)
    (2, 3, 80, 'gramas'),
    -- Insumo: Cream Cheese
    (2, 16, 20, 'gramas'),
    -- Insumo: Pepino
    (2, 4, 2, 'unidade')


-- Inserir prato de Gyoza
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Gyoza', 'Pastéis recheados com carne e legumes', 1, 8.99, 'Porção', NULL);


-- Inserir prato de Tataki de Salmão
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Tataki de Salmão', 'Salmão fresco levemente grelhado e fatiado, servido com molho ponzu e cebolinha', 2, 21.99, 'Porção', NULL);


-- Inserir novo prato Sunomono
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Sunomono', 'Salada de pepino finamente fatiado com molho agridoce', 1, 8.99, 'Porção', NULL);

INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Saquê', 'Saquê japonês tradicional', 8, 15.99, 'Garrafa', NULL);

-- Inserir bebida 5
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Chá Verde', 'Chá verde japonês', 8, 6.99, 'Xícara', NULL);

-- Inserir bebida 12
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Coquetel de Frutas', 'Coquetel de frutas tropicais com ou sem álcool', 8, 7.99, 'Copo', NULL);

-- Inserir novo prato 20
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Donburi de Salmão', 'Tigela de arroz coberta com salmão fresco', 4, 19.99, 'Unidade', NULL);

-- Inserir novo prato 31
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Gyudon', 'Tigela de arroz com carne de boi, cebola e molho especial', 4, 15.99, 'Porção', NULL);

-- Inserir novo prato 35
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Tofu Frito', 'Tofu crocante servido com molho especial', 3, 8.99, 'Porção', NULL);

-- Sobremesas

INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Dorayaki', 'Bolo recheado com pasta de feijão doce', 9, 5.99, 'unidade', NULL)

INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Mochi', 'Bolinhos de arroz glutinoso com diversos sabores', 9, 3.99, 'unidade', NULL)

INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Taiyaki', 'Waffle em forma de peixe recheado', 9, 4.99, 'unidade', NULL)

-----------sobremesas
INSERT INTO Produtos (nome_produto, descricao, id_categoriaprod, preco, unidade_medida, img_prato)
VALUES ('Dorayaki', 'Bolo recheado com pasta de feijão doce', 9, 5.99, 'unidade', NULL),
('Mochi', 'Bolinhos de arroz glutinoso com diversos sabores', 9, 3.99, 'unidade', NULL),
('Taiyaki', 'Waffle em forma de peixe recheado', 9, 4.99, 'unidade', NULL);
-----------------------------FAVORITOS-----------------------------------------------------------------------------------------------
-----------------------------FAVORITOS-----------------------------------------------------------------------------------------------
INSERT INTO Favorito (cpf, id_produto) VALUES ('12345678900', 1);
INSERT INTO Favorito (cpf, id_produto) VALUES ('12345678900', 2);
INSERT INTO Favorito (cpf, id_produto) VALUES ('12345678900', 3);
---------------------------------------------------------------------------------------------------------------------------
-- Inserir avaliação 1
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 1, 5, 'Produto excelente!', GETDATE());

-- Inserir avaliação 2
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 2, 4, 'Muito bom, mas pode melhorar.', GETDATE());

-- Inserir avaliação 3
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 3, 5, 'Recomendo a todos!', GETDATE());

-- Inserir avaliação 4
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 4, 3, 'Produto ok.', GETDATE());

-- Inserir avaliação 5
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 5, 4, 'Bom custo-benefício.', GETDATE());

-- Inserir avaliação 6
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 6, 2, 'Não gostei muito.', GETDATE());

-- Inserir avaliação 7
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 7, 5, 'Maravilhoso!', GETDATE());

-- Inserir avaliação 8
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 8, 4, 'Recomendo para todos.', GETDATE());

-- Inserir avaliação 9
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 9, 3, 'Poderia ser melhor.', GETDATE());

-- Inserir avaliação 10
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 10, 4, 'Boa qualidade.', GETDATE());

-- Inserir avaliação 11
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 11, 5, 'Excelente escolha!', GETDATE());

-- Inserir avaliação 12
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 12, 3, 'Poderia ser mais barato.', GETDATE());

-- Inserir avaliação 13
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 13, 4, 'Gostei bastante.', GETDATE());

-- Inserir avaliação 14
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 14, 5, 'Top demais!', GETDATE());

-- Inserir avaliação 15
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 15, 2, 'Não atendeu minhas expectativas.', GETDATE());

-- Inserir avaliação 16
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 16, 4, 'Bom produto, recomendo.', GETDATE());

-- Inserir avaliação 17
INSERT INTO Avaliacao (cpf, id_produto, estrelas, comentario_avaliacao, data_avaliacao)
VALUES ('12345678900', 17, 5, 'Fantástico!', GETDATE());
---------------------------------------------------------------------------------------------------------------------------
drop procedure usp_loginFunc

CREATE PROCEDURE usp_loginFunc
    @email varchar(100),
    @senha varchar(8)
AS
BEGIN
    IF CHARINDEX('@', @email) > 1 AND CHARINDEX('.', @email) > 1 AND
       @email LIKE '%_@__%.__%' AND (LEN(@senha) = 8)
    BEGIN
        IF (SELECT COUNT(*) FROM Funcionario WHERE email = @email AND senha = @senha) = 1
            SELECT 'Login aceito'
        ELSE
            SELECT 'Login recusado'
    END
    ELSE
    BEGIN
        SELECT 'Email ou senha invalidos'
    END
END

exec usp_loginFunc "joao", 12345678
exec usp_loginFunc "joao.souza@gmail.com", 12345678
--------------------------------------------------------------------------------------------------
drop procedure usp_loginCliente

CREATE PROCEDURE usp_loginCliente
    @email varchar(100),
    @senha varchar(MAX)
AS
BEGIN
    IF CHARINDEX('@', @email) > 1 AND CHARINDEX('.', @email) > 1 AND
       @email LIKE '%_@__%.__%' AND (LEN(@senha) >= 8)
    BEGIN
        IF (SELECT COUNT(*) FROM Cliente WHERE email = @email AND senha = @senha) = 1
            SELECT 'Login aceito'
        ELSE
            SELECT 'Login recusado'
    END
    ELSE
    BEGIN
        SELECT 'Email ou senha inválidos'
    END
END

exec usp_loginCliente 'Fulano@gmail.com', '23456474'

---------------------------------------------------------------------------------------------------
drop procedure usp_cadastrarCliente

CREATE PROCEDURE usp_cadastrarCliente
    @cpf VARCHAR(11),
    @nome VARCHAR(50),
    @telefone VARCHAR(20),
    @email VARCHAR(50),
	@senha VARCHAR(MAX)
AS
BEGIN
    IF CHARINDEX('@', @email) > 1 AND CHARINDEX('.', @email) > 1 AND
       @email LIKE '%_@__%.__%' AND (LEN(@senha) >= 8)
	BEGIN
       IF NOT EXISTS (SELECT * FROM Cliente WHERE cpf = @cpf OR email = @email)
          INSERT INTO Cliente (cpf, nome, telefone, email, senha)
        VALUES (@cpf, @nome, @telefone, @email, @senha)
	 ELSE
	   SELECT 'O CPF ou EMAIL já cadastrado, não é possivel realizar o cadastro'
	  END
	ELSE
	 BEGIN
	  SELECT 'Informe um Email ou uma senha válida'
     END
END

EXEC usp_cadastrarCliente '12345678901', 'Fulano de Tal', '(11) 1234-5678', 'Fulano@gmail.com', '23456474'
EXEC usp_cadastrarCliente '12345678901', 'Fulano de Tal', '(11) 1234-5678', 'maria.silva@gmail.com', '3456'

---------------------------------------------------------------------------------------------------
drop procedure usp_fazer_reserva

CREATE PROCEDURE usp_fazer_reserva
    @cpf VARCHAR(11),
    @numero_mesa INT,
    @data_reserva DATETIME,
    @quantidade_pessoas INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Cliente WHERE cpf = @cpf)
    BEGIN
        IF EXISTS (SELECT 1 FROM Mesa WHERE numero_mesa = @numero_mesa AND status_mesa = 'Disponível')
        BEGIN
            -- Verificar se já existe uma reserva para a mesma mesa e data
            DECLARE @reserva_existente INT;
            SELECT @reserva_existente = COUNT(*)
            FROM Reserva
            WHERE numero_mesa = @numero_mesa
            AND data_reserva = @data_reserva;

            IF @reserva_existente = 0
            BEGIN
                -- Verificar se há uma reserva existente com uma diferença de 2 horas ou mais
                DECLARE @diferenca_horas INT;
                SELECT TOP 1 @diferenca_horas = ABS(DATEDIFF(HOUR, data_reserva, @data_reserva))
                FROM Reserva
                WHERE numero_mesa = @numero_mesa
                AND data_reserva >= DATEADD(HOUR, -2, @data_reserva) -- Reservas nas últimas 2 horas
                ORDER BY data_reserva DESC;

                IF @diferenca_horas IS NULL OR @diferenca_horas >= 2
                BEGIN
                    INSERT INTO Reserva (cpf, numero_mesa, data_reserva, quantidade_pessoas)
                    VALUES (@cpf, @numero_mesa, @data_reserva, @quantidade_pessoas);

                    SELECT 'Reserva realizada com sucesso!';
                END
                ELSE
                BEGIN
                    SELECT 'Já existe uma reserva para esta mesa com menos de 2 horas de diferença.';
                END
            END
            ELSE
            BEGIN
                SELECT 'Já existe uma reserva para esta mesa na mesma data e hora.';
            END
        END
        ELSE
        BEGIN
            SELECT 'A mesa selecionada não está disponível.';
        END
    END
    ELSE
    BEGIN
        SELECT 'CPF não cadastrado ou incorreto.';
    END
END;

-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('11111111100', 'João Oliveira', '(11) 88888-8888', 'joao.oliveira@gmail.com', '1985-03-15', 'M', 'senha123');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '11111111100', 3, '2023-12-05 14:00', 4;

-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('22222222201', 'Pedro Santos', '(11) 77777-7777', 'pedro.santos@gmail.com', '1988-07-21', 'M', 'senha456');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '22222222201', 3, '2023-12-07 18:00', 5;

-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('33333333302', 'Ana Pereira', '(11) 66666-6666', 'ana.pereira@gmail.com', '1992-12-10', 'F', 'senha789');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '33333333302', 3, '2023-12-10 12:30', 3;

-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('44444444403', 'Mário Silva', '(11) 55555-5555', 'mario.silva@gmail.com', '1980-04-02', 'M', 'senha321');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '44444444403', 2, '2023-12-12 00:18', 7;


-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('55555555504', 'Carla Sousa', '(11) 44444-4444', 'carla.sousa@gmail.com', '1995-08-18', 'F', 'senha654');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '55555555504', 3, '2023-12-05 22:00', 2;

-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('66666666605', 'Ricardo Almeida', '(11) 33333-3333', 'ricardo.almeida@gmail.com', '1987-06-25', 'M', 'senha987');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '66666666605', 3, '2023-12-20 17:30', 6;




-- Inserir novo cliente
INSERT INTO Cliente (cpf, nome, telefone, email, data_nascimento, sexo, senha)
VALUES ('25500105400', 'Gu', '(11) 97841-5323', 'gusilva@gmail.com', '1987-06-25', 'M', 'senha987');

-- Fazer uma reserva para o novo cliente
exec usp_fazer_reserva '66666666605', 3, '2023-12-05 19:00', 6;

select * from Mesa
UPDATE 

Insert into Reserva (cpf, numero_mesa, data_reserva, quantidade_pessoas)
VALUES ('22222222201', 3, '2023-12-05 21:00', 2)

SELECT * FROM Reserva
SELECT * FROM Cliente


SELECT c.nome,
       p.quantidade_pessoas,
       p.data_reserva AS data,
       FORMAT(p.data_reserva, 'HH:mm') AS horario_reserva
FROM Reserva p
LEFT JOIN Cliente c ON p.cpf = c.cpf
WHERE p.numero_mesa = 3
      AND p.data_reserva > GETDATE()
ORDER BY p.data_reserva ASC;


DELETE Reserva
WHERE cpf = 22222222201

select * from Mesa

UPDATE Mesa
SET status_mesa = 'Disponivel'
WHERE numero_mesa = 3

UPDATE Reserva
SET ativo = 1
WHERE cpf = 22222222201

UPDATE Reserva
SET ativo = 0
WHERE cpf = 33333333302

UPDATE Reserva
SET ativo = 0
WHERE cpf = 44444444403

UPDATE Reserva
SET ativo = 0
WHERE cpf = 55555555504

UPDATE Reserva
SET ativo = 0
WHERE cpf = 66666666605

UPDATE Reserva SET ativo = 0 WHERE data_reserva = '2023-10-29 11:00' AND cpf = 12345678900
select * from Reserva

-------------------------------------------------------------------------------------------------------------
drop proc usp_AtualizarClienteEReserva

CREATE PROCEDURE usp_AtualizarClienteEReserva
    @CPFCliente VARCHAR(20),
    @NomeCliente VARCHAR(100),
    @NumeroMesa INT,
    @NovaDataHoraReserva DATETIME,
    @NovaQuantidadePessoas INT
AS
BEGIN
    -- Verifique se o cliente com o CPF fornecido existe
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE cpf = @CPFCliente)
    BEGIN
        THROW 50000, 'O cliente com o CPF fornecido não foi encontrado.', 1;
        RETURN;
    END;

    -- Verifique se a mesa com o número fornecido existe e está ativa
    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE numero_mesa = @NumeroMesa AND ativo = 1)
    BEGIN
        THROW 50001, 'A mesa especificada não existe ou não está ativa.', 1;
        RETURN;
    END;

    -- Atualizar o nome do cliente
    UPDATE Cliente
    SET nome = @NomeCliente
    WHERE cpf = @CPFCliente;

    -- Atualizar os dados da reserva
    UPDATE Reserva
    SET
        cpf = @CPFCliente,
        data_reserva = @NovaDataHoraReserva,
        quantidade_pessoas = @NovaQuantidadePessoas
    WHERE numero_mesa = @NumeroMesa AND ativo = 1 AND cpf = @CPFCliente;
END

EXEC usp_AtualizarClienteEReserva '12345678901', 'Editado', 3, '2023-10-31 15:00', 8

SELECT * FROM Reserva

DELETE FROM Reserva
WHERE cpf = '11111111100';

-------------------------------------------------------------------------------------------------------------
drop procedure usp_cancelar_reserva

CREATE PROCEDURE usp_cancelar_reserva
    @cpf VARCHAR(11),
    @numero_mesa INT,
    @data_reserva DATETIME
AS
BEGIN
    -- Verificar se a reserva existe e está ativa
    DECLARE @existe_reserva INT;
    SELECT @existe_reserva = COUNT(*)
    FROM Reserva
    WHERE cpf = @cpf AND numero_mesa = @numero_mesa AND data_reserva = @data_reserva AND ativo = 1;

    IF @existe_reserva > 0
    BEGIN
        -- Cancelar a reserva
        UPDATE Reserva
        SET ativo = 0
        WHERE cpf = @cpf AND numero_mesa = @numero_mesa AND data_reserva = @data_reserva;

        -- Verificar o status da mesa
        DECLARE @status_mesa VARCHAR(100);
        SELECT @status_mesa = status_mesa
        FROM Mesa
        WHERE numero_mesa = @numero_mesa;

        IF @status_mesa = 'Reservado'
        BEGIN
            -- Se o status da mesa estiver "Reservado," defina-o como "Disponível"
            UPDATE Mesa
            SET status_mesa = 'Disponível'
            WHERE numero_mesa = @numero_mesa;
        END

        SELECT 'Reserva cancelada!';
    END
    ELSE
    BEGIN
        SELECT 'Não foi possível cancelar a reserva. Verifique se os dados informados estão corretos.';
    END
END

select * from Reserva
exec usp_cancelar_reserva '11111111100', 3, '2023-11-05 10:00'
-------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_InserirPedido
    @cpf VARCHAR(11),
    @data_pedido DATETIME,
    @formapagamento VARCHAR(100),
    @numero_mesa INT,
    @produtos AS dbo.ProdutosType READONLY
AS
BEGIN
    DECLARE @id_pedido INT;
    DECLARE @status_mesa VARCHAR(100);
    DECLARE @ultimo_pedido_cpf VARCHAR(11);

    -- Verificar o status da mesa
    SELECT @status_mesa = status_mesa
    FROM Mesa
    WHERE numero_mesa = @numero_mesa;

    -- Verificar se a mesa está ocupada
    IF @status_mesa = 'Ocupada'
    BEGIN
        -- Obter o CPF do último pedido da mesma mesa
        SELECT TOP 1 @ultimo_pedido_cpf = p.cpf
        FROM Pedido p
        WHERE p.numero_mesa = @numero_mesa
        ORDER BY p.data_pedido DESC;

        -- Verificar se o CPF é diferente do último pedido
        IF @cpf <> @ultimo_pedido_cpf
        BEGIN
            SELECT 'Não é permitido realizar um novo pedido com CPF diferente na mesma mesa.';
            RETURN;
        END
    END

    -- Verificar se a mesa está reservada para a mesma data ou hora do pedido
    IF @status_mesa = 'Reservada'
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM Reserva rm
            WHERE rm.numero_mesa = @numero_mesa
            AND (DATEPART(Day, rm.data_reserva) = DATEPART(DAY, @data_pedido)) AND DATEPART(HOUR, rm.data_reserva) = DATEPART(HOUR, @data_pedido))
        BEGIN
            SELECT 'Não é permitido realizar um pedido em uma mesa reservada para a mesma data ou hora.';
            RETURN;
        END
    END

    -- Iniciar uma transação para garantir a integridade dos dados
    BEGIN TRANSACTION;

    -- Inserir o pedido na tabela Pedido
    INSERT INTO Pedido (cpf, data_pedido, valor_total, formapagamento, numero_mesa)
    VALUES (@cpf, CONVERT(DATETIME, @data_pedido, 120), 1, @formapagamento, @numero_mesa);

    -- Obter o ID do pedido recém-inserido
    SET @id_pedido = SCOPE_IDENTITY();

    -- Inserir os detalhes do pedido na tabela DetalhesPedido
    INSERT INTO DetalhesPedido (id_pedido, id_produto, quantidade_produto, valor_unitario)
SELECT @id_pedido, dp.id_produto, dp.quantidade_produto, p.preco
FROM @produtos dp
JOIN Produtos p ON dp.id_produto = p.id_produto;

    -- Atualizar o valor total do pedido
    UPDATE Pedido
    SET valor_total = (
        SELECT SUM(d.quantidade_produto * d.valor_unitario)
        FROM DetalhesPedido d
        WHERE d.id_pedido = @id_pedido
    )
    WHERE id_pedido = @id_pedido;

    -- Ocupar a mesa
    UPDATE Mesa
    SET status_mesa = 'Ocupada'
    WHERE numero_mesa = @numero_mesa;

    -- Inserir o status do pedido na tabela StatusPedido
    INSERT INTO StatusPedido (id_pedido)
    VALUES (@id_pedido);

    
    -- Subtrair os insumos do estoque com base nos produtos do pedido
UPDATE Insumos
SET estoque = estoque - (
    SELECT SUM(dp.quantidade_produto * ip.quantidade_insumo)
    FROM @produtos dp
    JOIN InsumosProduto ip ON dp.id_produto = ip.id_produto
    WHERE ip.id_insumo = Insumos.id_insumo
)
WHERE id_insumo IN (
    SELECT ip.id_insumo
    FROM @produtos dp
    JOIN InsumosProduto ip ON dp.id_produto = ip.id_produto
);
    -- Commit da transação, confirmando as mudanças no banco de dados
    COMMIT TRANSACTION;
END;
-----------------------------------------------------------------------
select * from Produtos
--executar a procedure acima
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (4, 2),
    (5, 1),
    (1, 1)
	
EXEC usp_InserirPedido
    @cpf = '12345678900',
    @data_pedido = '2023-12-04T21:30:00',
    @formapagamento = 'Cartão de crédito',
    @numero_mesa = 3,
    @produtos = @produtos

-------------------------------------------------
select nome, cpf from Cliente

-- Execução 1
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (1, 1),
    (7, 1),
    (28, 1)

EXEC usp_InserirPedido
    @cpf = '11111111100',
    @data_pedido = '2023-12-04T18:45:00',
    @formapagamento = 'Dinheiro',
    @numero_mesa = 1,
    @produtos = @produtos;

-- Execução 3
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (5, 3),
    (12, 1),
    (18, 2)

EXEC usp_InserirPedido
    @cpf = '22222222201',
    @data_pedido = '2023-12-04T19:45:00',
    @formapagamento = 'Cartão de Débito',
    @numero_mesa = 10,
    @produtos = @produtos;

-- Execução 4
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (4, 1),
    (10, 2),
    (16, 1)

EXEC usp_InserirPedido
    @cpf = '33333333302',
    @data_pedido = '2023-12-04T20:15:00',
    @formapagamento = 'Pix',
    @numero_mesa = 15,
    @produtos = @produtos;

-- Execução 5
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (3, 1),
    (9, 1),
    (14, 3)

EXEC usp_InserirPedido
    @cpf = '44444444403',
    @data_pedido = '2023-12-04T20:45:00',
    @formapagamento = 'Dinheiro',
    @numero_mesa = 3,
    @produtos = @produtos;

-- Execução 6
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (6, 2),
    (11, 1),
    (17, 2)

EXEC usp_InserirPedido
    @cpf = '55555555504',
    @data_pedido = '2023-12-04T21:15:00',
    @formapagamento = 'Cartão de Crédito',
    @numero_mesa = 8,
    @produtos = @produtos;

-- Execução 7
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (2, 1),
    (8, 2),
    (13, 1)

EXEC usp_InserirPedido
    @cpf = '66666666605',
    @data_pedido = '2023-12-04T21:45:00',
    @formapagamento = 'Pix',
    @numero_mesa = 12,
    @produtos = @produtos;

drop procedure usp_InserirPedido
---------------------------------------------------------------------------------------------------------
drop procedure usp_InserirPedidoFunc

CREATE PROCEDURE usp_InserirPedidoFunc
   @id_funcionario INT,
    @data_pedido DATETIME,
    @formapagamento VARCHAR(100),
    @numero_mesa INT,
    @produtos AS dbo.ProdutosType READONLY
AS
BEGIN
    DECLARE @id_pedido INT;

    -- Iniciar uma transação para garantir a integridade dos dados
    BEGIN TRANSACTION;

    -- Inserir o pedido na tabela Pedido
    INSERT INTO Pedido (id_funcionario, data_pedido, valor_total, formapagamento, numero_mesa)
    VALUES (@id_funcionario, CONVERT(DATETIME, @data_pedido, 120), 0.0, @formapagamento, @numero_mesa);

    -- Obter o ID do pedido recém-inserido
    SET @id_pedido = SCOPE_IDENTITY();

    -- Inserir os detalhes do pedido na tabela DetalhesPedido
    INSERT INTO DetalhesPedido (id_pedido, id_produto, quantidade_produto, valor_unitario)
    SELECT @id_pedido, dp.id_produto, dp.quantidade_produto, p.preco
    FROM @produtos dp
    JOIN Produtos p ON dp.id_produto = p.id_produto;

    -- Atualizar o valor total do pedido
    UPDATE Pedido
    SET valor_total = (
        SELECT SUM(d.quantidade_produto * d.valor_unitario)
        FROM DetalhesPedido d
        WHERE d.id_pedido = @id_pedido
    )
    WHERE id_pedido = @id_pedido;

    -- Ocupar a mesa

	select * from Mesa

    UPDATE Mesa
    SET status_mesa = 'Disponivel'
    WHERE numero_mesa = 3;

    -- Inserir o status do pedido na tabela StatusPedido
    INSERT INTO StatusPedido (id_pedido)
    VALUES (@id_pedido);

    -- Subtrair os insumos do estoque com base nos produtos do pedido
    UPDATE Insumos
    SET estoque = estoque - (
        SELECT SUM(dp.quantidade_produto * ip.quantidade_insumo)
        FROM @produtos dp
        JOIN InsumosProduto ip ON dp.id_produto = ip.id_produto
        WHERE ip.id_insumo = Insumos.id_insumo
    )
    WHERE id_insumo IN (
        SELECT ip.id_insumo
        FROM @produtos dp
        JOIN InsumosProduto ip ON dp.id_produto = ip.id_produto
    );

    -- Commit da transação, confirmando as mudanças no banco de dados
    COMMIT TRANSACTION;
END
-----------------------------------------------------------------------
select * from Funcionario
--executar a procedure acima
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (4, 1),
    (2, 1),
    (1, 1), 
    (3, 1),
    (5, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 5,
    @data_pedido = '2023-05-19T12:34:56',
    @formapagamento = 'Cartão de crédito',
    @numero_mesa = 7,
    @produtos = @produtos

-- Execução 1
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (1, 3),
    (7, 1),
    (18, 2)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 1,
    @data_pedido = '2023-12-04T18:45:00',
    @formapagamento = 'Dinheiro',
    @numero_mesa = 1,
    @produtos = @produtos;

-- Execução 2
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (2, 2),
    (8, 1),
    (15, 3)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 2,
    @data_pedido = '2023-12-04T19:15:00',
    @formapagamento = 'Cartão de Crédito',
    @numero_mesa = 5,
    @produtos = @produtos;

-- Execução 3
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (5, 3),
    (12, 1),
    (18, 2)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 3,
    @data_pedido = '2023-12-04T19:45:00',
    @formapagamento = 'Cartão de Débito',
    @numero_mesa = 10,
    @produtos = @produtos;

-- Execução 4
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (4, 1),
    (10, 2),
    (16, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 4,
    @data_pedido = '2023-12-04T20:15:00',
    @formapagamento = 'Pix',
    @numero_mesa = 15,
    @produtos = @produtos;

-- Execução 5
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (3, 1),
    (9, 1),
    (14, 3)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 5,
    @data_pedido = '2023-12-04T20:45:00',
    @formapagamento = 'Dinheiro',
    @numero_mesa = 3,
    @produtos = @produtos;

-- Execução 6
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (6, 2),
    (11, 1),
    (17, 2)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 6,
    @data_pedido = '2023-12-04T21:15:00',
    @formapagamento = 'Cartão de Crédito',
    @numero_mesa = 8,
    @produtos = @produtos;

-- Execução 7
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (2, 1),
    (8, 2),
    (13, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 7,
    @data_pedido = '2023-12-04T21:45:00',
    @formapagamento = 'Pix',
    @numero_mesa = 12,
    @produtos = @produtos;

-- Execução 8
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (5, 1),
    (12, 1),
    (18, 3)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 8,
    @data_pedido = '2023-12-04T22:15:00',
    @formapagamento = 'Cartão de Débito',
    @numero_mesa = 18,
    @produtos = @produtos;

-- Execução 9
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (1, 2),
    (7, 1),
    (16, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 9,
    @data_pedido = '2023-12-04T22:45:00',
    @formapagamento = 'Dinheiro',
    @numero_mesa = 6,
    @produtos = @produtos;

-- Execução 10
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (3, 3),
    (9, 2),
    (14, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 10,
    @data_pedido = '2023-12-04T23:15:00',
    @formapagamento = 'Cartão de Crédito',
    @numero_mesa = 14,
    @produtos = @produtos;

-- Execução 11
DECLARE @produtos dbo.ProdutosType;

INSERT INTO @produtos (id_produto, quantidade_produto)
VALUES
    (4, 1),
    (10, 2),
    (15, 1)

EXEC usp_InserirPedidoFunc
    @id_funcionario = 11,
    @data_pedido = '2023-12-04T23:45:00',
    @formapagamento = 'Pix',
    @numero_mesa = 17,
    @produtos = @produtos;

drop procedure usp_InserirPedidoFunc
--------------------------------------------------------------------------------------------------
drop procedure usp_InserirFuncionario

CREATE PROCEDURE usp_InserirFuncionario
    @cpf VARCHAR(11),
    @nome VARCHAR(100),
    @telefone VARCHAR(20),
    @sexo CHAR(1),
    @dataNascimento DATE,
    @cep VARCHAR(10),
    @endereco VARCHAR(100),
    @email VARCHAR(100),
    @senha VARCHAR(8),
    @dataContratacao DATE,
    @cargo VARCHAR(50),
    @turno VARCHAR(30),
    @salario DECIMAL(10, 2),
    @img_func VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Funcionario (cpf, nome, telefone, sexo, data_nascimento, cep, endereco, email, senha, data_contratacao, cargo, turno, salario, img_func)
    VALUES (@cpf, @nome, @telefone, @sexo, @dataNascimento, @cep, @endereco, @email, @senha, @dataContratacao, @cargo, @turno, @salario, @img_func)
END

EXEC usp_InserirFuncionario '12345678901', 'Nome do Funcionário', '1234-5678', 'M', '1990-01-01', '12345-678', 'Endereço do Funcionário', 'email@exemplo.com', 'senha123', '2023-01-01', 'Atendente', 'Diurno', 1500.00, NULL
--------------------------------------------------------------------------------------------------
drop procedure usp_DesabilitarFuncionario

CREATE PROCEDURE usp_DesabilitarFuncionario
    @funcionarioID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Funcionario WHERE id_funcionario = @funcionarioID)
    BEGIN
        THROW 50001, 'Funcionário não encontrado.', 1;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Funcionario WHERE id_funcionario = @funcionarioID AND ativo = 1)
    BEGIN
        THROW 50002, 'Funcionário já está desativado.', 1;
        RETURN;
    END

    UPDATE Funcionario SET ativo = 0 WHERE id_funcionario = @funcionarioID;

    SELECT 'Funcionário desativado com sucesso.' AS Mensagem;
END

EXEC usp_DesabilitarFuncionario 1

UPDATE Funcionario SET ativo = 1 WHERE id_funcionario = 3;
---------------------------------------------------------------------------------------------------------------	
drop proc usp_AtualizarProduto

CREATE PROCEDURE usp_AtualizarProduto
    @ProdutoId INT,
    @Nome VARCHAR(50),
    @Descricao VARCHAR(200),
    @Preco DECIMAL(10, 2),
    @CategoriaId INT,
    @UnidadeMedida VARCHAR(10),
    @Imagem VARBINARY(MAX)
AS
BEGIN
    UPDATE Produtos
    SET nome_produto = @Nome,
        descricao = @Descricao,
        preco = @Preco,
        id_categoriaprod = @CategoriaId,
        unidade_medida = @UnidadeMedida,
        img_prato = @Imagem
    WHERE id_produto = @ProdutoId;
END
---------------------------------------------------------------------------------------------------------------	
drop proc usp_DesativarProduto

CREATE PROCEDURE usp_DesativarProduto
    @produtoID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Produtos WHERE id_produto = @produtoID)
    BEGIN
        THROW 50001, 'Produto não encontrado.', 1;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Produtos WHERE id_produto = @produtoID AND ativo = 1)
    BEGIN
        THROW 50002, 'Produto já está desativado.', 1;
        RETURN;
    END

    -- Produto está ativo, então podemos desativá-lo
    UPDATE Produtos SET ativo = 0 WHERE id_produto = @produtoID;

    SELECT 'Produto desativado com sucesso.' AS Mensagem;
END

EXEC usp_DesativarProduto 17

UPDATE Produtos SET ativo = 1 WHERE id_produto = 18
---------------------------------------------------------------------------------------------------------------
drop proc usp_InserirInsumo

CREATE PROCEDURE usp_InserirInsumo
    @nome_insumo NVARCHAR(255),
    @descricao NVARCHAR(1000),
    @estoque DECIMAL(18, 2),
    @id_fornecedor INT,
    @unidade_medida NVARCHAR(50),
    @data_entrada DATE,
    @data_validade DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica se o fornecedor é válido
    IF NOT EXISTS (SELECT 1 FROM Fornecedor WHERE id_fornecedor = @id_fornecedor AND ativo = 1)
    BEGIN
        PRINT 'Fornecedor inválido. Selecione um fornecedor válido.';
        RETURN;
    END

    -- Verifique se o estoque é um número positivo
    IF @estoque < 0
    BEGIN
        PRINT 'Estoque inválido. Certifique-se de que o estoque seja um número válido maior ou igual a zero.';
        RETURN;
    END

    -- Verifique se a data de validade não é anterior à data de entrada
    IF @data_validade < @data_entrada
    BEGIN
        PRINT 'A data de validade não pode ser anterior à data de entrada.';
        RETURN;
    END

    -- Insere o novo insumo na tabela Insumos
    INSERT INTO Insumos (nome_insumo, descricao, estoque, id_fornecedor, unidade_medida, data_entrada, data_validade)
    VALUES (@nome_insumo, @descricao, @estoque, @id_fornecedor, @unidade_medida, @data_entrada, @data_validade);

    IF @@ERROR = 0
    BEGIN
        PRINT 'Insumo inserido com sucesso.';
    END
    ELSE
    BEGIN
        PRINT 'Erro ao inserir insumo.';
    END
END
---------------------------------------------------------------------------------------------------------------
drop proc usp_AtualizarInsumo

CREATE PROCEDURE usp_AtualizarInsumo
    @InsumoID INT,
    @NomeInsumo NVARCHAR(50),
    @Descricao NVARCHAR(200),
    @Estoque NUMERIC(10, 2),
    @IdFornecedor INT,
    @UnidadeMedida NVARCHAR(20),
    @DataEntrada DATE,
    @DataValidade DATE
AS
BEGIN
    UPDATE Insumos
    SET
        nome_insumo = @NomeInsumo,
        descricao = @Descricao,
        estoque = @Estoque,
        id_fornecedor = @IdFornecedor,
        unidade_medida = @UnidadeMedida,
        data_entrada = @DataEntrada,
        data_validade = @DataValidade
    WHERE
        id_insumo = @InsumoID;
END

--Exec da procedure acima

DECLARE @InsumoID INT = 1; -- Substitua 1 pelo valor correto
DECLARE @NomeInsumo NVARCHAR(50) = 'Nome do Insumo'; -- Substitua pelo nome correto
DECLARE @Descricao NVARCHAR(200) = 'Descrição do Insumo'; -- Substitua pela descrição correta
DECLARE @Estoque NUMERIC(10, 2) = 100.50; -- Substitua pelo valor de estoque correto
DECLARE @IdFornecedor INT = 2; -- Substitua pelo ID do fornecedor correto
DECLARE @UnidadeMedida NVARCHAR(20) = 'Unidade'; -- Substitua pala unidade de medida correta
DECLARE @DataEntrada DATE = '2023-10-13'; -- Substitua pela data de entrada correta
DECLARE @DataValidade DATE = '2023-12-31'; -- Substitua pela data de validade correta

EXEC usp_AtualizarInsumo
    @InsumoID,
    @NomeInsumo,
    @Descricao,
    @Estoque,
    @IdFornecedor,
    @UnidadeMedida,
    @DataEntrada,
    @DataValidade;
	select * from Reserva

SELECT R.numero_mesa, R.cpf, C.nome, R.data_reserva, R.quantidade_pessoas
FROM Reserva AS R
INNER JOIN Cliente AS C ON R.cpf = C.cpf
WHERE R.numero_mesa = 3
AND R.data_reserva >= GETDATE()
AND R.Ativo = 1
ORDER BY R.data_reserva

---------------------------------------------------------------------------------------------------------------
drop proc usp_DesativarInsumo

CREATE PROCEDURE usp_DesativarInsumo
    @InsumoID INT
AS
BEGIN
    UPDATE Insumos
    SET ativo = 0
    WHERE id_insumo = @InsumoID;
END

exec usp_DesativarInsumo 38

---------------------------------------------------------------------------------------------------------------
drop proc usp_InserirFornecedor

CREATE PROCEDURE usp_InserirFornecedor
    @nome_fornecedor NVARCHAR(255),
    @telefone NVARCHAR(20),
    @email NVARCHAR(255),
    @endereco NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica se o nome do fornecedor não está em branco
    IF LTRIM(RTRIM(@nome_fornecedor)) = ''
    BEGIN
        PRINT 'O nome do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Verifica se o telefone não está em branco
    IF LTRIM(RTRIM(@telefone)) = ''
    BEGIN
        PRINT 'O telefone do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Verifica se o email não está em branco
    IF LTRIM(RTRIM(@email)) = ''
    BEGIN
        PRINT 'O email do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Insere o novo fornecedor na tabela Fornecedor
    INSERT INTO Fornecedor (nome_fornecedor, telefone, email, endereco)
    VALUES (@nome_fornecedor, @telefone, @email, @endereco);

    IF @@ERROR = 0
    BEGIN
        PRINT 'Fornecedor inserido com sucesso.';
    END
    ELSE
    BEGIN
        PRINT 'Erro ao inserir fornecedor.';
    END
END
---------------------------------------------------------------------------------------------------------------
drop proc usp_AtualizarFornecedor

CREATE PROCEDURE usp_AtualizarFornecedor
    @FornecedorID INT,
    @nome_fornecedor NVARCHAR(255),
    @telefone NVARCHAR(20),
    @email NVARCHAR(255),
    @endereco NVARCHAR(1000)
AS
BEGIN
    -- Verifica se o nome do fornecedor não está em branco
    IF LTRIM(RTRIM(@nome_fornecedor)) = ''
    BEGIN
        PRINT 'O nome do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Verifica se o telefone não está em branco
    IF LTRIM(RTRIM(@telefone)) = ''
    BEGIN
        PRINT 'O telefone do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Verifica se o email não está em branco
    IF LTRIM(RTRIM(@email)) = ''
    BEGIN
        PRINT 'O email do fornecedor não pode estar em branco.';
        RETURN;
    END

    -- Atualiza o fornecedor na tabela Fornecedor
    UPDATE Fornecedor
    SET
        nome_fornecedor = @nome_fornecedor,
        telefone = @telefone,
        email = @email,
        endereco = @endereco
    WHERE
        id_fornecedor = @FornecedorID;

    IF @@ERROR = 0
    BEGIN
        PRINT 'Fornecedor atualizado com sucesso.';
    END
    ELSE
    BEGIN
        PRINT 'Erro ao atualizar fornecedor.';
    END
END
---------------------------------------------------------------------------------------------------------------
drop proc usp_DesativarFornecedor

CREATE PROCEDURE usp_DesativarFornecedor
    @FornecedorID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifique se o fornecedor existe e está ativo
    IF NOT EXISTS (SELECT 1 FROM Fornecedor WHERE id_fornecedor = @FornecedorID AND ativo = 1)
    BEGIN
        PRINT 'Fornecedor não encontrado ou já está desativado.';
        RETURN;
    END

    -- Desative o fornecedor
    UPDATE Fornecedor
    SET ativo = 0
    WHERE id_fornecedor = @FornecedorID;

    IF @@ERROR = 0
    BEGIN
        PRINT 'Fornecedor desativado com sucesso.';
    END
    ELSE
    BEGIN
        PRINT 'Erro ao desativar fornecedor.';
    END
END

---------------------------------------------------------------------------------------------------------------
	DELETE FROM Pedido WHERE id_pedido = 12


SELECT r.data_reserva, r.quantidade_pessoas, c.nome, r.cpf
FROM Reserva r
INNER JOIN Cliente c ON r.cpf = c.cpf
WHERE r.numero_mesa = 3 AND r.ativo = 0
ORDER BY r.data_reserva DESC

/*
select * from Pedido
select * from DetalhesPedido
select * from InsumosProduto
select * from Insumos
select * from Cliente
select * from Funcionario
select * from StatusPedido
select * from Mesa
select * from Fornecedor
select * from Avaliacao
select * from Reserva
select * from CategoriaProduto
select * from Produtos
select * from Favorito
*/

/*
SELECT pe.id_pedido, pe.numero_mesa, p.nome_produto, dp.quantidade_produto 
                       FROM Pedido pe 
                       INNER JOIN DetalhesPedido dp ON pe.id_pedido = dp.id_pedido
                       INNER JOIN Produtos p ON p.id_produto = dp.id_produto
                       INNER JOIN StatusPedido sp ON pe.id_pedido = sp.id_pedido
                       WHERE sp.status_pedido = 'Em Preparo' 
                       ORDER BY pe.id_pedido ASC

					   UPDATE StatusPedido SET status_pedido = 'Pronto' WHERE id_pedido = 1

					   UPDATE Mesa SET status_mesa = 'Disponível' WHERE numero_mesa = 4

					   insert into Produtos (img_prato)

					   UPDATE Produtos SET img_prato = NULL WHERE nome_produto = 'Hot Roll'


SELECT
    p.id_pedido,pr.img_prato,
    pr.nome_produto,
    dp.quantidade_produto,
    CONVERT(VARCHAR(5), p.data_pedido, 108) AS hora_pedido,
    sp.status_pedido
FROM Pedido p
JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido
JOIN Produtos pr ON dp.id_produto = pr.id_produto
JOIN StatusPedido sp ON p.id_pedido = sp.id_pedido
WHERE p.id_pedido = (SELECT MAX(id_pedido) FROM Pedido WHERE numero_mesa = 5)
ORDER BY dp.id_pedido, dp.id_produto;

SELECT TOP 1
    c.nome
FROM Pedido p
JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido
JOIN Produtos pr ON dp.id_produto = pr.id_produto
JOIN StatusPedido sp ON p.id_pedido = sp.id_pedido
JOIN Cliente c ON p.cpf = c.cpf
WHERE p.id_pedido = (SELECT MAX(id_pedido) FROM Pedido WHERE numero_mesa = 4)
ORDER BY dp.id_pedido, dp.id_produto;


SELECT pe.id_pedido, pe.cpf, pe.valor_total, CONVERT(VARCHAR, pe.data_pedido, 103) as data FROM Pedido pe 
WHERE pe.numero_mesa = (SELECT numero_mesa FROM Mesa Where numero_mesa = 4)


SELECT 
    p.id_pedido,
    c.cpf,
    p.valor_total,
    CONVERT(varchar, p.data_pedido, 103) as data_pedido,
    COUNT(dp.id_produto) as quantidade_produtos
FROM Pedido p
JOIN Cliente c ON p.cpf = c.cpf
LEFT JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido
WHERE p.numero_mesa = 5
GROUP BY 
    p.id_pedido,
    c.cpf,
    p.valor_total,
    p.data_pedido;
	
	
	SELECT 
    p.id_pedido,
    f.id_funcionario,
    p.valor_total,
    CONVERT(varchar, p.data_pedido, 103) as data_pedido,
    COUNT(dp.id_produto) as quantidade_produtos
FROM Pedido p
JOIN Funcionario f ON p.id_funcionario = f.id_funcionario
LEFT JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido
WHERE p.numero_mesa = 7
GROUP BY 
    p.id_pedido,
    f.id_funcionario, 
    p.valor_total,
    p.data_pedido;
	*/

	Select p.id_produto, p.nome_produto,p.descricao, p.preco, p.img_prato, c.nome_categoria, a.estrelas
                from Produtos p 
                left Join CategoriaProduto c on p.id_categoriaprod = c.id_categoriaprod
                left join Avaliacao a on p.id_produto = a.id_produto

				select p.nome_produto, c.nome_categoria from Produtos p left join CategoriaProduto c on p.id_categoriaprod = c.id_categoriaprod


	SELECT 
    p.id_pedido,
    c.cpf,
    f.id_funcionario,
    p.valor_total,
    CONVERT(varchar, p.data_pedido, 103) as data_pedido,
    COUNT(dp.id_produto) as quantidade_produtos
FROM Pedido p
LEFT JOIN Cliente c ON p.cpf = c.cpf
LEFT JOIN Funcionario f ON p.id_funcionario = f.id_funcionario
LEFT JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido
WHERE p.numero_mesa = 7
GROUP BY 
    p.id_pedido,
    c.cpf,
    f.id_funcionario, 
    p.valor_total,
    p.data_pedido;

	select c.nome, p.quantidade_pessoas, Convert(varchar, p.data_reserva, 103) as data, FORMAT(p.data_reserva, 'HH:mm') AS horario_reserva from Reserva p LEFT JOIN Cliente c ON p.cpf = c.cpf where numero_mesa = 2 AND data_reserva > GETDATE() order by data, horario_reserva asc

	select Convert(varchar, data_reserva, 103) as data, FORMAT(data_reserva, 'HH:mm') AS horario_reserva From Reserva where numero_mesa = 2 and DATEDIFF(day, data_reserva, GETDATE()) = 0 and DATEDIFF(Hour, data_reserva, GETDATE()) < 0 or DATEDIFF(Hour, data_reserva, GETDATE()) > -1

	select *,DATEDIFF(hour, data_reserva, GETDATE()), DATEDIFF(DAY, data_reserva, GETDATE()) From Reserva where numero_mesa = 2

	SELECT 
    CONVERT(varchar, data_reserva, 103) as data, 
    FORMAT(data_reserva, 'HH:mm') AS horario_reserva 
FROM 
    Reserva 
WHERE 
    numero_mesa = 2 
    AND data_reserva >= GETDATE() 
    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());

	select getDate()

	INSERT INTO Reserva (cpf, numero_mesa, data_reserva, quantidade_pessoas)
                    VALUES (12345678900, 2, '2023-16-09 17:54:00', 4);

	String consulta = "SELECT \n" +
                "    p.id_pedido, \n" +
                "    c.cpf,  \n" +
                "    p.valor_total, \n" +
                "    CONVERT(varchar, p.data_pedido, 103) as data_pedido, \n" +
                "    COUNT(dp.id_produto) as quantidade_produtos \n" +
                "FROM Pedido p \n" +
                "JOIN Cliente c ON p.cpf = c.cpf \n" +
                "LEFT JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido \n" +
                "WHERE p.numero_mesa = "+ productMesa.getNum_mesa()  +
                "GROUP BY\n" +
                "    p.id_pedido,\n" +
                "    c.cpf,\n" +
                "    p.valor_total,\n" +
                "    p.data_pedido; ";

				UPDATE Mesa SET status_mesa = 'dispo', id_funcionario = 1 WHERE numero_mesa = 1

				SELECT Count(*) FROM Pedido WHERE email = 1
				SELECT Count(*) FROM Mesa WHERE numero_mesa = 1 and id_funcionario = 1