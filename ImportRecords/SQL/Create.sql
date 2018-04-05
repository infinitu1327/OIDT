CREATE SCHEMA "Parameters"
  AUTHORIZATION postgres;

CREATE SCHEMA "Events"
  AUTHORIZATION postgres;

CREATE SCHEMA "Gender"
  AUTHORIZATION postgres;

CREATE TABLE "Parameters"."CurrencyPurchase"
(
  "Id" integer PRIMARY KEY,
  "Income" integer NOT NULL,
  "Name" text,
  "Price" numeric NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Events"."CurrencyPurchase"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Parameters"."FirstLaunch"
(
  "Id" integer PRIMARY KEY,
  "Age" integer NOT NULL,
  "Country" text,
  "Gender" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Events"."FirstLaunch"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);
CREATE TABLE "Events"."GameLaunch"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Parameters"."InGamePurchase"
(
  "Id" integer PRIMARY KEY,
  "Item" text,
  "Price" integer NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Events"."InGamePurchase"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Parameters"."StageEnd"
(
  "Id" integer PRIMARY KEY,
  "Income" integer,
  "Stage" integer NOT NULL,
  "Time" integer NOT NULL,
  "Win" boolean NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Events"."StageEnd"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Parameters"."StageStart"
(
  "Id" integer PRIMARY KEY,
  "Stage" integer NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE "Events"."StageStart"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

ALTER TABLE "Parameters"."StageStart"
  OWNER TO postgres;
ALTER TABLE "Parameters"."CurrencyPurchase"
  OWNER TO postgres;
ALTER TABLE "Parameters"."FirstLaunch"
  OWNER TO postgres;
ALTER TABLE "Parameters"."InGamePurchase"
  OWNER TO postgres;
ALTER TABLE "Parameters"."StageEnd"
  OWNER TO postgres;
ALTER TABLE "Events"."StageStart"
  OWNER TO postgres;
ALTER TABLE "Events"."CurrencyPurchase"
  OWNER TO postgres;
ALTER TABLE "Events"."FirstLaunch"
  OWNER TO postgres;
ALTER TABLE "Events"."GameLaunch"
  OWNER TO postgres;
ALTER TABLE "Events"."InGamePurchase"
  OWNER TO postgres;
ALTER TABLE "Events"."StageEnd"
OWNER TO postgres;