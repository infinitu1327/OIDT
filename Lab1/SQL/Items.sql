CREATE VIEW public."Items" AS
SELECT 
  "Events"."InGamePurchase"."Date",
  COUNT(*),
  SUM("Parameters"."InGamePurchase"."Price") * 10 AS "TotalPrice",
  SUM("Parameters"."InGamePurchase"."Price" * public."CurrencyRate"."CurrencyRate") * 10 AS "PriceInUSD"
FROM 
  "Parameters"."InGamePurchase", 
  "Events"."InGamePurchase",
  public."CurrencyRate"
WHERE 
  "Events"."InGamePurchase"."ParametersId" = "Parameters"."InGamePurchase"."Id"
GROUP BY 
  "Events"."InGamePurchase"."Date";
