CREATE VIEW public."Revenue" as 
SELECT 
  "Events"."CurrencyPurchase"."Date", 
  Sum("Parameters"."CurrencyPurchase"."Price")*10 as "Revenue"
FROM 
  "Events"."CurrencyPurchase", 
  "Parameters"."CurrencyPurchase"
WHERE 
  "Events"."CurrencyPurchase"."ParametersId" = "Parameters"."CurrencyPurchase"."Id"
GROUP BY
  "Events"."CurrencyPurchase"."Date";
