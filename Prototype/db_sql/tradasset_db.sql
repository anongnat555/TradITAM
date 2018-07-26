create database tradasset;

create table user_login (
  user_id int NOT NULL AUTO_INCREMENT primary key,
  username varchar(50),
  password varchar(128),
  user_role int,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table history(
  history_id int primary key,
  user_id int,
  references_id int,
  detail text,
  history_timestamp datetime,
  history_type int
);

create table asset_history(
  asset_history_id int primary key,
  user_id int,
  asset_id int,
  asset_history_type int,
  remark text,
  history_timestamp datetime
);

create table asset_history_type (
  asset_history_type_id int primary key,
  type_code varchar(100),
  type_description text,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table asset(
  asset_id int primary key,
  os_id int,
  asset_type_id int,
  original_supplier_id int,
  supplier_id int,
  using_by_staff_id int,
  asset_code varchar(50),
  brand varchar(100),
  price decimal(10,2),
  cpu varchar(100),
  ram varchar(100),
  hdd varchar(100),
  notes text,
  start_date_warranty date,
  expiry_date_warranty date,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table os (
  os_id int primary key,
  os_name varchar(100),
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table asset_type(
  asset_type_id int primary key,
  asset_type_name varchar(100),
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table staff(
  staff_id int primary key ,
  firstname varchar(100),
  lastname varchar(100),
  aka varchar(50),
  start_date date,
  end_date date,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table supplier(
  supplier_id int primary key,
  company_name varchar(200),
  contact_person varchar(200),
  address varchar(400),
  email varchar(200),
  phone varchar(20),
  is_active bit,
  create_date datetime,
  modified_date datetime
);