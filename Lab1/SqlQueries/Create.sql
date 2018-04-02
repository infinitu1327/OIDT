CREATE SCHEMA parameters
  AUTHORIZATION postgres;

CREATE SCHEMA events
  AUTHORIZATION postgres;

CREATE TABLE parameters."CurrencyPurchase"
(
  "Id" integer PRIMARY KEY,
  "Income" integer NOT NULL,
  "Name" text,
  "Price" numeric NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE events."CurrencyPurchase"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE parameters."FirstLaunch"
(
  "Id" integer PRIMARY KEY,
  "Age" integer NOT NULL,
  "Country" text,
  "Gender" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE events."FirstLaunch"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);
CREATE TABLE events."GameLaunch"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE parameters."InGamePurchase"
(
  "Id" integer PRIMARY KEY,
  "Item" text,
  "Price" integer NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE events."InGamePurchase"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE parameters."StageEnd"
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

CREATE TABLE events."StageEnd"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

CREATE TABLE parameters."StageStart"
(
  "Id" integer PRIMARY KEY,
  "Stage" integer NOT NULL
)
WITH (
  OIDS=FALSE
);

CREATE TABLE events."StageStart"
(
  "Id" integer PRIMARY KEY,
  "Date" timestamp without time zone NOT NULL,
  "ParametersId" integer NOT NULL,
  "Udid" text
)
WITH (
  OIDS=FALSE
);

ALTER TABLE parameters."StageStart"
  OWNER TO postgres;
ALTER TABLE parameters."CurrencyPurchase"
  OWNER TO postgres;
ALTER TABLE parameters."FirstLaunch"
  OWNER TO postgres;
ALTER TABLE parameters."GameLaunch"
  OWNER TO postgres;
ALTER TABLE parameters."InGamePurchase"
  OWNER TO postgres;
ALTER TABLE parameters."StageEnd"
  OWNER TO postgres;
ALTER TABLE events."StageStart"
  OWNER TO postgres;
ALTER TABLE events."CurrencyPurchase"
  OWNER TO postgres;
ALTER TABLE events."FirstLaunch"
  OWNER TO postgres;
ALTER TABLE events."GameLaunch"
  OWNER TO postgres;
ALTER TABLE events."InGamePurchase"
  OWNER TO postgres;
ALTER TABLE events."StageEnd"
OWNER TO postgres;