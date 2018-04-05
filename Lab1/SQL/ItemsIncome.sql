CREATE VIEW "ItemsIncome" AS
SELECT 
  parameters."InGamePurchase"."Item", 
  SUM (parameters."InGamePurchase"."Price") * 10
FROM 
  parameters."InGamePurchase"
GROUP BY
  parameters."InGamePurchase"."Item";
