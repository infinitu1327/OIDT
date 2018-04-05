CREATE VIEW "Gender"."DAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Gender", 
  "Events"."FirstLaunch"."Date",
  Count(*)*10 AS "Count"
FROM 
  "Events"."FirstLaunch",
  "Parameters"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Gender",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Gender"."MAU" AS
SELECT 
  "Parameters"."FirstLaunch"."Gender",
  "Events"."FirstLaunch"."Date",
  Count(DISTINCT "Udid") * 10 as "Count"
FROM 
  "Parameters"."FirstLaunch",
  "Events"."FirstLaunch"
WHERE
  "Events"."FirstLaunch"."ParametersId" = "Parameters"."FirstLaunch"."Id"
GROUP BY 
  "Parameters"."FirstLaunch"."Gender",
  "Events"."FirstLaunch"."Date";

CREATE VIEW "Gender"."Revenue" as 
SELECT 
  "Parameters"."FirstLaunch"."Gender",
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
  "Parameters"."FirstLaunch"."Gender",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Gender"."Rate" AS
SELECT 
  "Parameters"."FirstLaunch"."Gender",
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
  "Parameters"."FirstLaunch"."Gender",
  "Events"."CurrencyPurchase"."Date";

CREATE VIEW "Gender"."Stages" AS
SELECT 
  "Parameters"."FirstLaunch"."Gender",
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
  "Parameters"."FirstLaunch"."Gender",
  "Events"."StageEnd"."Date";

CREATE VIEW "Gender"."Items" AS
SELECT 
  "Parameters"."FirstLaunch"."Gender", 
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
  "Parameters"."FirstLaunch"."Gender",
  "Events"."InGamePurchase"."Date";
