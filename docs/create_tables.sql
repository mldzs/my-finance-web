create table plano_contas(
	id int identity(1,1),
	tipo char(1) not null,
	descricao varchar(50) not null,
	primary key(id)
)

create table transacao(
	id bigint identity(1,1),
	data date not null,
	tipo char(1) not null,
	descricao varchar(50) null,
	valor decimal(9,2) not null,
	id_plano_conta int not null,
	primary key(id),
	foreign key (id_plano_conta) references plano_contas(id)
)

use myfinance

insert into plano_contas(tipo,descricao) values('C','Salário');
insert into plano_contas(tipo,descricao) values('C','Aluguel');
insert into plano_contas(tipo,descricao) values('C','Juros Aplicação');
insert into plano_contas(tipo,descricao) values('C','Dividendos');

insert into plano_contas(tipo,descricao) values('D','Supermercado');
insert into plano_contas(tipo,descricao) values('D','Restaurante');
insert into plano_contas(tipo,descricao) values('D','Combustível');
insert into plano_contas(tipo,descricao) values('D','Gás de Cozinha');
insert into plano_contas(tipo,descricao) values('D','Água');
insert into plano_contas(tipo,descricao) values('D','Luz');
insert into plano_contas(tipo,descricao) values('D','Telefone');
insert into plano_contas(tipo,descricao) values('D','Internet');
insert into plano_contas(tipo,descricao) values('D','Seguro Carro');
insert into plano_contas(tipo,descricao) values('D','Netflix');
insert into plano_contas(tipo,descricao) values('D','IPTU');
insert into plano_contas(tipo,descricao) values('D','IPVA');

select * from plano_contas

insert into transacao(data,tipo,descricao,valor,id_plano_conta)
values('2022-08-04 10:32', 'D','Gasolina Blazer', 450.36, 7);

insert into transacao(data,tipo,descricao,valor,id_plano_conta)
values('2022-08-04 19:54', 'D','Compras do Mês', 750.48, 5);

insert into transacao(data,tipo,descricao,valor,id_plano_conta)
values('2022-08-01 00:00', 'C','Salário Empresa X', 32000, 1);

select * from transacao
