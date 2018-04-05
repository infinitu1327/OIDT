CREATE VIEW public."CurrencyRate" AS
SELECT 
  "Events"."CurrencyPurchase"."Date", 
  Sum("Parameters"."CurrencyPurchase"."Price") / Sum("Parameters"."CurrencyPurchase"."Income") as "CurrencyRate"
FROM 
  "Events"."CurrencyPurchase", 
  "Parameters"."CurrencyPurchase"  
WHERE 
  "Events"."CurrencyPurchase"."ParametersId" = "Parameters"."CurrencyPurchase"."Id"
GROUP BY
  "Events"."CurrencyPurchase"."Date";
