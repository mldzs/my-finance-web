create database my_finance;

use my_finance;

create table plano_contas(
	id int identity(1, 1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,

	primary key(id)
);

create table transacao(
	id bigint identity (1, 1) not null,
	data datetime not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,

	primary key(id),
	foreign key(id_plano_conta) references plano_contas
);

-- Inser�ao de alguns exemplos

insert into plano_contas(descricao, tipo) values ('Aluguel', 'D');
insert into plano_contas(descricao, tipo) values ('Alimenta��o', 'D');
insert into plano_contas(descricao, tipo) values ('Combust�vel', 'D');
insert into plano_contas(descricao, tipo) values ('Viagens', 'D');
insert into plano_contas(descricao, tipo) values ('Sal�rio', 'C');


insert into transacao(data, valor, tipo, historico, id_plano_conta)
	values ('2022-08-11 21:35:00', 100.47, 'D', 'Gasolina para viagem', 3);
insert into transacao(data, valor, tipo, historico, id_plano_conta)
	values ('2022-08-11 21:35:00', 48.32, 'D', 'Almo�o', 2);
insert into transacao(data, valor, tipo, historico, id_plano_conta)
	values (getdate()-1, 35.87, 'D', 'Almo�o', 2);
insert into transacao(data, valor, tipo, historico, id_plano_conta)
	values (getdate()-10, 10000.00, 'C', 'Sal�rio Empresa X', 2);


SELECT sum(valor) as both
FROM transacao
WHERE  data BETWEEN  '1/1/2022' AND '1/31/2022';

SELECT sum(valor) as despesa
FROM transacao
WHERE  tipo = 'D' AND  data BETWEEN  '1/1/2022' AND '1/31/2022';

SELECT sum(valor) as receita
FROM transacao
WHERE  tipo = 'R' AND  data BETWEEN  '1/1/2022' AND '1/31/2022';


SELECT(SELECT COALESCE(sum(valor), 0) from transacao t where t.TIPO = 'D' and [DATA] >= '1/1/2021' and [DATA] <= '1/31/2021' ) as sum_despesas,
(SELECT COALESCE(sum(valor), 0) from transacao t where t.TIPO = 'R' and [DATA] >= '1/1/2021' and [DATA] <= '1/31/2021') as sum_receita