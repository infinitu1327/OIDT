CREATE TABLE public.revenue as 
SELECT 
  date, 
  Sum(price) * 10 as revenue
FROM 
  events.currency_purchase, 
  parameters.currency_purchase
WHERE 
  parameters_id = parameters.currency_purchase.id
GROUP BY
  date
ORDER BY
  date;