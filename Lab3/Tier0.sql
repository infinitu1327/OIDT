CREATE VIEW "Tier0"."DAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Tier0", 
  "Events"."FirstLaunch"."Date",
  Count(*)*10 AS "Count"
FROM 
  "Events"."FirstLaunch",
  "Parameters"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id" AND
  "Events"."FirstLaunch"."Udid" IN (
      SELECT 
        "Events"."CurrencyPurchase"."Udid" 
      FROM 
        "Events"."CurrencyPurchase",
        "Parameters"."CurrencyPurchase"
      WHERE 
        "Events"."CurrencyPurchase"."ParametersId" = "Parameters"."CurrencyPurchase"."Id" AND
        "Parameters"."CurrencyPurchase"."Price" = 0
      )
GROUP BY 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Tier0"."MAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."FirstLaunch"."Date",
  Count(DISTINCT "Udid") * 10 as "Count"
FROM 
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Tier0"."Revenue" as 
SELECT 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."CurrencyPurchase"."Date", 
  Sum("Parameters"."CurrencyPurchase"."Price")*10 as "Revenue"
FROM 
  "Events"."CurrencyPurchase", 
  "Parameters"."CurrencyPurchase",
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE 
  "Events"."CurrencyPurchase"."ParametersId" = "Parameters"."CurrencyPurchase"."Id" AND
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Tier0"."Rate" AS
SELECT 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."CurrencyPurchase"."Date", 
  Sum("Parameters"."CurrencyPurchase"."Price") / Sum("Parameters"."CurrencyPurchase"."Income") as "CurrencyRate"
FROM 
  "Events"."CurrencyPurchase", 
  "Parameters"."CurrencyPurchase",
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE 
  "Events"."CurrencyPurchase"."ParametersId" = "Parameters"."CurrencyPurchase"."Id" AND
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Tier0"."Stages" AS
SELECT 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."StageEnd"."Date",
  Count("Events"."StageStart"."Id") * 10 as "StartCount",
  Count("Events"."StageEnd"."Id") * 10 as "EndCount",
  Sum("Parameters"."StageEnd"."Income") * 10  AS "Income",
  Sum(public."CurrencyRate"."CurrencyRate" * "Income") as "Revenue"
FROM 
  "Events"."StageStart",
  "Events"."StageEnd",
  "Parameters"."StageEnd",
  public."CurrencyRate",
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE 
  "Events"."StageEnd"."ParametersId" = "Parameters"."StageEnd"."Id" AND
  "Events"."StageEnd"."Date" = public."CurrencyRate"."Date" AND
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."StageEnd"."Date";

CREATE VIEW "Tier0"."Items" AS
SELECT 
  "Parameters"."FirstLaunch"."Tier0", 
  "Events"."InGamePurchase"."Date",
  COUNT(*),
  SUM("Parameters"."InGamePurchase"."Price") * 10 AS "TotalPrice",
  SUM("Parameters"."InGamePurchase"."Price" * public."CurrencyRate"."CurrencyRate") * 10 AS "PriceInUSD"
FROM 
  "Parameters"."InGamePurchase", 
  "Events"."InGamePurchase",
  public."CurrencyRate",
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE 
  "Events"."InGamePurchase"."ParametersId" = "Parameters"."InGamePurchase"."Id" AND
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Tier0",
  "Events"."InGamePurchase"."Date";
