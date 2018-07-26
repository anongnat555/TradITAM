create database itam_db;

create table staff(
  staff_id varchar(10) primary key not null ,
  name varchar(30) not null
);

create table admin_login(
  admin_id varchar(10) primary key not null ,
  password varchar(15) not null
);

create table item_type(
  type_id int primary key not null ,
  name varchar(30) not null
);

create table supplier(
  supplier_id varchar(10) primary key not null ,
  name varchar(50) not null ,
  email text,
  phone varchar(15) not null,
  address text,
  contact_person varchar(50)
);

create table item(
  item_id varchar(10) primary key not null ,
  brand varchar(30) not null ,
  series varchar(30) not null ,
  price decimal(10,2),
  is_active bit,
  insurance_start date,
  insurance_end date,
  type_id int references item_type(type_id),
  staff_id varchar(10) references staff(staff_id),
  supplier_id varchar(10) references supplier(supplier_id)
);

create table pc(
  pc_id varchar(10) references item(item_id) not null ,
  os varchar(30),
  cpu varchar(30),
  ram varchar(30),
  hdd varchar(30)
);

create table fix_history(
  supplier_id varchar(10) references supplier(supplier_id),
  item_id varchar(10) references item(item_id),
  status varchar(1) not null ,
  description text ,
  date timestamp
);

create table require_history(
  staff_id varchar(10) references staff(staff_id),
  item_id varchar(10) references item(item_id),
  status varchar(1) not null ,
  description text ,
  date timestamp
);

insert into admin_login values ('admin', 'admin');
-- SET TIME ZONE local;
-- select now()