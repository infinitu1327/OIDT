CREATE VIEW "Age"."DAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Age", 
  "Events"."FirstLaunch"."Date",
  Count(*)*10 AS "Count"
FROM 
  "Events"."FirstLaunch",
  "Parameters"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Age",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Age"."MAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Age",
  "Events"."FirstLaunch"."Date",
  Count(DISTINCT "Udid") * 10 as "Count"
FROM 
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Age",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Age"."Revenue" as 
SELECT 
  "Parameters"."FirstLaunch"."Age",
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
  "Parameters"."FirstLaunch"."Age",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Age"."Rate" AS
SELECT 
  "Parameters"."FirstLaunch"."Age",
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
  "Parameters"."FirstLaunch"."Age",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Age"."Stages" AS
SELECT 
  "Parameters"."FirstLaunch"."Age",
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
  "Parameters"."FirstLaunch"."Age",
  "Events"."StageEnd"."Date";

CREATE VIEW "Age"."Items" AS
SELECT 
  "Parameters"."FirstLaunch"."Age", 
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
  "Parameters"."FirstLaunch"."Age",
  "Events"."InGamePurchase"."Date";
