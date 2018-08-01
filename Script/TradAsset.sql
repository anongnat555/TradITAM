

use TraditionAsset;

create table user_login (
  user_id int NOT NULL    IDENTITY    PRIMARY KEY,
  username varchar(50),
  password varchar(128),
  user_role int,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table history(
  history_id int NOT NULL    IDENTITY    PRIMARY KEY,
  user_id int,
  references_id int,
  detail text,
  history_timestamp datetime,
  history_type int
);

create table asset_history(
  asset_history_id int NOT NULL    IDENTITY    PRIMARY KEY,
  user_id int,
  asset_id int,
  asset_history_type int,
  remark text,
  history_timestamp datetime
);

create table asset_history_type (
  asset_history_type_id int NOT NULL    IDENTITY    PRIMARY KEY,
  type_code varchar(100),
  type_description text,
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table asset(
  asset_id int NOT NULL    IDENTITY    PRIMARY KEY,
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
  os_id int NOT NULL    IDENTITY    PRIMARY KEY,
  os_name varchar(100),
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table asset_type(
  asset_type_id int NOT NULL    IDENTITY    PRIMARY KEY,
  asset_type_name varchar(100),
  is_active bit,
  create_date datetime,
  modified_date datetime
);

create table staff(
  staff_id int NOT NULL    IDENTITY    PRIMARY KEY,
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
  supplier_id int NOT NULL    IDENTITY    PRIMARY KEY,
  company_name varchar(200),
  contact_person varchar(200),
  address varchar(400),
  email varchar(200),
  phone varchar(20),
  is_active bit,
  create_date datetime,
  modified_date datetime
);

alter table asset_history
add constraint asset_history_type_FK FOREIGN KEY ( asset_history_type ) references asset_history_type(asset_history_type_id)

alter table asset
add constraint asset_type_id_FK FOREIGN KEY ( asset_type_id ) references asset_type(asset_type_id)

alter table asset
add constraint os_id_FK FOREIGN KEY ( os_id ) references os(os_id)

alter table asset
add constraint supplier_id_FK FOREIGN KEY ( supplier_id ) references supplier(supplier_id)

alter table asset
add constraint original_supplier_id_FK FOREIGN KEY ( original_supplier_id ) references supplier(supplier_id)

alter table asset
add constraint using_by_staff_id_FK FOREIGN KEY ( using_by_staff_id ) references staff(staff_id)

alter table asset_history
add constraint asset_history_id_FK FOREIGN KEY ( user_id ) references user_login(user_id)

alter table history
add constraint historye_user_id_FK FOREIGN KEY ( user_id ) references user_login(user_id)