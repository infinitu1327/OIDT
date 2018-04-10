CREATE TABLE public.currency_rate AS
SELECT 
  events.currency_purchase.date, 
  Sum(price) / Sum(income) as rate
FROM 
  events.currency_purchase, 
  parameters.currency_purchase  
WHERE 
  parameters_id = parameters.currency_purchase.id
GROUP BY
  events.currency_purchase.date
ORDER BY
  date;