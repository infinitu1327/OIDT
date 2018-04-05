CREATE VIEW public."ItemsCount" AS
SELECT 
  "Events"."InGamePurchase"."Date",
  COUNT(*),
  SUM("Parameters"."InGamePurchase"."Price")
FROM 
  "Parameters"."InGamePurchase", 
  "Events"."InGamePurchase"
WHERE 
  "Events"."InGamePurchase"."ParametersId" = "Parameters"."InGamePurchase"."Id"
GROUP BY 
  "Events"."InGamePurchase"."Date";
