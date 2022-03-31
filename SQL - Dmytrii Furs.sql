-- LeetCode SQL - Dmytrii Furs
-- 175. Combine Two Tables (Easy)
SELECT p.firstName, p.lastName, a.city, a.state
FROM Person p
LEFT JOIN Address a 
ON a.personId = p.personId;

-- 176. Second Highest Salary (Medium) SELECT (SELECT ) to avoid nulls 
SELECT (SELECT DISTINCT salary 
FROM employee
ORDER BY salary DESC
LIMIT 1, 1) AS SecondHighestSalary;

-- 177. Nth Highest Salary (Medium)
CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  SET N = N - 1,
  RETURN (
      SELECT IFNULL(
      (SELECT DISTINCT salary
      FROM employee
      ORDER BY salary DESC
      LIMIT N, 1), NULL)
  )
END;

-- 178. Rank Scores (Medium)
SELECT score, DENSE_RANK() OVER (ORDER BY score DESC) AS 'rank'
FROM Scores
ORDER BY score DESC;

-- 180. Consecutive Numbers (Medium)
SELECT DISTINCT l1.Num AS ConsecutiveNums
FROM 
Logs l1, Logs l2, Logs l3
WHERE
l1.id = l2.id - 1
AND l2.id = l3.id - 1
AND l1.num = l2.num
AND l2.num = l3.num;

-- 181. Employees Earning More Than Their Managers (Easy)
SELECT
     a.NAME AS Employee
FROM Employee AS a JOIN Employee AS b
     ON a.ManagerId = b.Id
     AND a.Salary > b.Salary;

-- 182. Duplicate Emails (Easy)
SELECT Email
FROM Person
GROUP BY Email
HAVING COUNT(Email) != 1;

-- 183. Customers Who Never Order (Easy) 
SELECT Customers.name AS 'Customers'
FROM Customers
LEFT JOIN Orders ord 
ON ord.customerId = Customers.id 
WHERE ord.customerId IS NULL;

-- 184. Department Highest Salary (Medium)
SELECT d.name AS 'Department', e.Name AS 'Employee', e.salary
FROM employee e
INNER JOIN department d
ON e.departmentId = d.id
WHERE (e.departmentId, salary) IN
(SELECT 
 departmentId, MAX(salary)
 FROM 
 employee
 GROUP BY departmentId
);

-- 185. Department Top Three Salaries (Hard)
SELECT d.name AS 'Department', e1.name AS 'Employee', e1.salary
FROM employee e1
JOIN Department d 
ON e1.departmentId = d.id
WHERE 3 > 
(
SELECT COUNT(DISTINCT e2.salary)
FROM employee e2
WHERE e2.salary > e1.salary 
AND e1.departmentId = e2.departmentId
);

-- 196. Delete Duplicate Emails (Easy) 
DELETE FROM Person WHERE id NOT IN 
(SELECT * FROM (SELECT MIN(id) FROM person GROUP BY Email) as p);

-- 197. Rising Temperature (Easy) 
SELECT weather.id
FROM weather
JOIN weather w ON DATEDIFF(weather.recordDate, w.recordDate) = 1 AND weather.Temperature > w.Temperature;

-- 262. Trips and Users (Hard)
SELECT Request_at AS Day, ROUND(SUM(IF(status != 'completed',1,0))/COUNT(status),2) AS 'Cancellation Rate'
FROM Trips
WHERE Request_at >= "2013-10-01" AND Request_at <= "2013-10-03"
AND client_id NOT IN (
SELECT users_id FROM users WHERE Banned="Yes")
AND driver_id NOT IN (
SELECT users_id FROM users WHERE Banned="Yes")
GROUP BY Request_at;

-- 601. Human Traffic of Stadium (Hard) (In this task we need to find all consecutive rows, with at least 3 in a row, so  we need to
-- checkk all 3 possible outcomes - 1, 2, 3; 2, 1, 3; 3, 2, 1;
SELECT DISTINCT st1.id, st1.visit_date, st1.people
FROM stadium st1, stadium st2, stadium st3
WHERE 
st1.people >= 100
AND st2.people >= 100
AND st3.people >= 100
AND (
    (st1.id - st2.id = 1 AND st1.id - st3.id = 2 AND st2.id - st3.id = 1)
    OR
    (st2.id - st1.id = 1 AND st2.id - st3.id = 2 AND st1.id - st3.id = 1)
    OR
    (st3.id - st2.id = 1 AND st2.id - st1.id = 1 AND st3.id - st1.id = 2)
)
ORDER BY st1.id;

-- 596. Classes More Than 5 Students (Easy)
SELECT class
FROM courses
GROUP BY class
HAVING COUNT(DISTINCT student) >= 5;

-- 595. Big Countries (Easy) 
SELECT w.name, w.population, w.area
FROM World w
WHERE area >= 3000000 OR population >= 25000000;

-- 620. Not Boring Movies (Easy)
SELECT c.id, c.movie, c.description, c.rating
FROM Cinema c
WHERE c.description != 'boring' AND mod(c.id,2) = 1
ORDER BY rating DESC;

-- 626. Exchange Seats (Medium) 
SELECT 
 (CASE 
 WHEN MOD(id,2) != 0 AND counts != id then id + 1
 WHEN MOD(id,2) != 0 AND counts = id then id
 ELSE id - 1
 END) as id, student
FROM Seat,
(SELECT COUNT(*) AS counts
FROM seat) as seat_counts
ORDER BY id ASC;

--  627. Swap Salary (Easy) 
UPDATE Salary
SET 
    sex = CASE sex 
    WHEN 'm' THEN 'f'
    ELSE 'm'
    END;

-- 1179. Reformat Department Table (Easy) 
SELECT
id,
SUM(IF(month = 'Jan', revenue, NULL)) as Jan_Revenue,
SUM(IF(month = 'Feb', revenue, NULL)) as Feb_Revenue,
SUM(IF(month = 'Mar', revenue, NULL)) as Mar_Revenue,
SUM(IF(month = 'Apr', revenue, NULL)) as Apr_Revenue,
SUM(IF(month = 'May', revenue, NULL)) as May_Revenue,
SUM(IF(month = 'Jun', revenue, NULL)) as Jun_Revenue,
SUM(IF(month = 'Jul', revenue, NULL)) as Jul_Revenue,
SUM(IF(month = 'Aug', revenue, NULL)) as Aug_Revenue,
SUM(IF(month = 'Sep', revenue, NULL)) as Sep_Revenue,
SUM(IF(month = 'Oct', revenue, NULL)) as Oct_Revenue,
SUM(IF(month = 'Nov', revenue, NULL)) as Nov_Revenue,
SUM(IF(month = 'Dec', revenue, NULL)) as Dec_Revenue
FROM Department
GROUP BY id;


-- 586. Customer Placing the Largest Number of Orders (Easy)
SELECT customer_number
FROM orders
GROUP BY customer_number
ORDER BY COUNT(*) DESC
LIMIT 1;

-- 511. Game Play Analysis I (Easy)
SELECT player_id, MIN(event_date) AS 'first_login'
FROM activity
GROUP BY player_id

-- 584. Find Customer Referee (Easy)
SELECT name
FROM customer
WHERE referee_id != 2 OR referee_id IS NULL

-- 607. Sales Person (Easy)
SELECT sp.name
FROM SalesPerson sp
WHERE sp.sales_id NOT IN (
SELECT o.sales_id FROM orders o 
LEFT JOIN company c ON o.com_id = c.com_id
WHERE c.name = "RED")


-- 1795. Rearrange Products Table (Easy)
SELECT product_id, 'store1' as store, store1 as 'price'
FROM products
WHERE store1 IS NOT NULL
UNION
SELECT product_id, 'store2' as store, store2 as 'price'
FROM products
WHERE store2 IS NOT NULL
UNION
SELECT product_id, 'store3' as store, store3 as 'price'
FROM products
WHERE store3 IS NOT NULL

-- 1873. Calculate Special Bonus (Easy)

SELECT employee_id, salary AS 'bonus'  
FROM employees
WHERE name NOT LIKE 'M%' AND employee_id%2 != 0
UNION
SELECT employee_id, 0 AS 'bonus'  
FROM employees
WHERE name LIKE 'M%' OR employee_id%2 = 0
ORDER BY employee_id

-- 1050. Actors and Directors Who Cooperated At Least Three Times (Easy)
SELECT  actor_id, director_id  
FROM ActorDirector
GROUP BY  actor_id, director_id
HAVING COUNT(director_id) >= 3

-- 1890. The Latest Login in 2020 (Easy)
SELECT user_id, MAX(time_stamp) as last_stamp 
FROM Logins 
WHERE YEAR(time_stamp) = 2020
GROUP BY user_id;

-- 1965. Employees With Missing Information (Easy)
SELECT emp.employee_id  FROM Employees AS emp
LEFT JOIN Salaries AS sal ON emp.employee_id = sal.employee_id
WHERE sal.salary IS NULL
UNION
SELECT sal.employee_id  FROM Employees AS emp
RIGHT JOIN Salaries AS sal ON emp.employee_id = sal.employee_id
WHERE emp.name IS NULL
ORDER BY 1;


-- 1148. Article Views I (Easy)
SELECT DISTINCT author_id AS id
FROM views
WHERE author_id = viewer_id 
ORDER BY 1;


-- 1141. User Activity for the Past 30 Days I (Easy)
SELECT activity_date AS 'day', COUNT(DISTINCT user_id) AS 'active_users'
FROM Activity 
GROUP BY activity_date
HAVING activity_date >= '2019-06-28' AND activity_date <= '2019-07-27';


-- 1084. Sales Analysis III (Easy)
SELECT p.product_id, p.product_name 
FROM sales s
INNER JOIN Product p ON p.product_id = s.product_id
GROUP BY p.product_id
HAVING MIN(s.sale_date) >= "2019-01-01" AND MAX(s.sale_date) <= "2019-03-31";


-- 1158. Market Analysis I (Medium)
SELECT user_id AS buyer_id, join_date, IFNULL(num, 0) AS orders_in_2019
FROM users 
LEFT JOIN (
SELECT buyer_id, COUNT(*) AS NUM
FROM orders 
WHERE YEAR(order_date) = 2019
GROUP BY buyer_id
) AS res
ON users.user_id = res.buyer_id



-- 1757. Recyclable and Low Fat Products (Easy)
SELECT product_id
FROM products
WHERE low_fats = 'Y' AND recyclable = 'Y'


-- 1741. Find Total Time Spent by Each Employee (Easy)
SELECT event_day AS day, emp_id, SUM(out_time - in_time) AS total_time
FROM Employees 
GROUP BY event_day, emp_id


-- 1729. Find Followers Count (Easy)
SELECT user_id, COUNT(follower_id) AS followers_count
FROM followers
GROUP BY user_id
ORDER BY user_id;


-- 1693. Daily Leads and Partners (Easy)

SELECT date_id, make_name, COUNT(DISTINCT lead_id) AS unique_leads, COUNT(DISTINCT partner_id) AS unique_partners
FROM DailySales
GROUP BY 1, 2;


-- 1667. Fix Names in a Table (Easy)
SELECT user_id, CONCAT(UPPER(SUBSTRING(name, 1, 1)), LOWER(SUBSTRING(name, 2))) AS name
FROM users
ORDER BY 1;


-- 1587. Bank Account Summary II (Easy)
SELECT u.name, SUM(t.amount) AS balance
FROM users u
INNER JOIN Transactions t ON u.account = t.account
GROUP BY t.account
HAVING SUM(t.amount) > 10000;


-- 1581. Customer Who Visited but Did Not Make Any Transactions (Easy)
SELECT v.customer_id, COUNT(v.visit_id) AS 'count_no_trans'
FROM visits v
LEFT JOIN transactions t ON v.visit_id = t.visit_id
WHERE t.amount IS NULL
GROUP BY v.customer_id;


-- 1527. Patients With a Condition (Easy)
SELECT patient_id, patient_name, conditions
FROM patients
WHERE conditions LIKE "DIAB1%" OR conditions LIKE "% DIAB1%";


-- 1407. Top Travellers (Easy)
SELECT u.name, IFNULL(SUM(r.distance), 0) AS "travelled_distance"
FROM users u
LEFT JOIN rides r ON u.id = r.user_id
GROUP BY r.user_id
ORDER BY 2 DESC, 1;


-- 1484. Group Sold Products By The Date (Easy)
SELECT sell_date, COUNT(DISTINCT product) AS num_sold, GROUP_CONCAT(DISTINCT product) AS products
FROM activities
GROUP BY sell_date;