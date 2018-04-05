CREATE VIEW "StagesRevenue" AS
SELECT 
  public."CurrencyRate"."Date",
  public."CurrencyRate"."CurrencyRate" * public."StagesIncome"."Income" as "Income"
FROM 
  public."CurrencyRate",
  public."StagesIncome"
WHERE
  public."StagesIncome"."Date" = public."CurrencyRate"."Date";