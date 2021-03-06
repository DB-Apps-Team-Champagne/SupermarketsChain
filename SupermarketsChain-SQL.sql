--------------------------------------------------------
--  File created - Friday-July-24-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence MEASURES_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ADMIN"."MEASURES_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ADMIN"."PRODUCTS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ1
--------------------------------------------------------

   CREATE SEQUENCE  "ADMIN"."PRODUCTS_SEQ1"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ2
--------------------------------------------------------

   CREATE SEQUENCE  "ADMIN"."PRODUCTS_SEQ2"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence VENDORS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ADMIN"."VENDORS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table MEASURES
--------------------------------------------------------

  CREATE TABLE "ADMIN"."MEASURES" 
   (	"ID" NUMBER(*,0), 
	"MEASURENAME" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "ADMIN"."PRODUCTS" 
   (	"ID" NUMBER(*,0), 
	"VENDORID" NUMBER(*,0), 
	"PRODUCTNAME" VARCHAR2(50 BYTE), 
	"MEASUREID" NUMBER(*,0), 
	"PRICE" NUMBER(18,2)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table VENDORS
--------------------------------------------------------

  CREATE TABLE "ADMIN"."VENDORS" 
   (	"ID" NUMBER(*,0), 
	"VENDORNAME" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into ADMIN.MEASURES
SET DEFINE OFF;
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (1,'liters');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (2,'pieces');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (3,'kg');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (4,'pound');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (5,'cm');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (6,'foot');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (7,'gallon');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (8,'inch');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (9,'celsius');
Insert into ADMIN.MEASURES (ID,MEASURENAME) values (10,'grams');
REM INSERTING into ADMIN.PRODUCTS
SET DEFINE OFF;
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (1,2,'Beer "Zagorka"',1,0.99);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (2,3,'Vodka "Targovishte"',1,8.7);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (3,2,'Beer "Beck''s"',1,1.65);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (4,1,'Chocolate "Milka"',2,2.8);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (5,1,'Kit Kat - varieties',2,0.65);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (6,4,'Sudjuk - "Orehite"',10,5.43);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (7,4,'Hlqb',10,0.76);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (8,5,'Samsung s4',2,560.99);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (9,2,'Whiskey - The Walker ',1,22.99);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (10,6,'Vadica',2,50);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (11,6,'Glock - patlak',2,300);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (12,6,'Korda za vadica',5,15);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (13,7,'Slushalki za cs',2,100);
Insert into ADMIN.PRODUCTS (ID,VENDORID,PRODUCTNAME,MEASUREID,PRICE) values (14,7,'TV - "Phillips"',8,1200);
REM INSERTING into ADMIN.VENDORS
SET DEFINE OFF;
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (1,'Nestle Sofia Corp.');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (2,'Zagorka Corp.');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (3,'Targovishte Bottling Company Ltd.');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (4,'Mesarq - Sofiq OOD');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (5,'Telephones Ltd.');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (6,'Lov i Ribolov - Petrich OOD');
Insert into ADMIN.VENDORS (ID,VENDORNAME) values (7,'Technomarket');
--------------------------------------------------------
--  DDL for Index MEASURES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ADMIN"."MEASURES_PK" ON "ADMIN"."MEASURES" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ADMIN"."PRODUCTS_PK" ON "ADMIN"."PRODUCTS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  Constraints for Table MEASURES
--------------------------------------------------------

  ALTER TABLE "ADMIN"."MEASURES" ADD CONSTRAINT "MEASURES_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ADMIN"."MEASURES" MODIFY ("MEASURENAME" NOT NULL ENABLE);
  ALTER TABLE "ADMIN"."MEASURES" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "ADMIN"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "ADMIN"."PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "ADMIN"."PRODUCTS" MODIFY ("MEASUREID" NOT NULL ENABLE);
  ALTER TABLE "ADMIN"."PRODUCTS" MODIFY ("PRODUCTNAME" NOT NULL ENABLE);
  ALTER TABLE "ADMIN"."PRODUCTS" MODIFY ("VENDORID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table VENDORS
--------------------------------------------------------

  ALTER TABLE "ADMIN"."VENDORS" MODIFY ("VENDORNAME" NOT NULL ENABLE);
  ALTER TABLE "ADMIN"."VENDORS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Trigger MEASURES_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ADMIN"."MEASURES_TRG" 
BEFORE INSERT ON ADMIN.MEASURES 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING THEN
      SELECT MEASURES_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "ADMIN"."MEASURES_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRODUCTS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ADMIN"."PRODUCTS_TRG" 
BEFORE INSERT ON ADMIN.PRODUCTS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    NULL;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "ADMIN"."PRODUCTS_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRODUCTS_TRG1
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ADMIN"."PRODUCTS_TRG1" 
BEFORE INSERT ON ADMIN.PRODUCTS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT PRODUCTS_SEQ2.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "ADMIN"."PRODUCTS_TRG1" ENABLE;
--------------------------------------------------------
--  DDL for Trigger VENDORS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ADMIN"."VENDORS_TRG" 
BEFORE INSERT ON ADMIN.VENDORS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING THEN
      SELECT VENDORS_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "ADMIN"."VENDORS_TRG" ENABLE;
