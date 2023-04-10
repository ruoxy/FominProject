create table Users
(
id int primary key identity(1,1),
first_name varchar(20) not null,
user_email varchar(40) unique,
user_role varchar(20) not null,
user_passord varchar(20) not null
)

create table Filterr
(
category_id int primary key,
category_name varchar(50) not null,
product_id int not null,
product_name varchar(50) not null,
popular bit not null,
price int not null,
sale int not null,
)

create table Product 
(
product_id int primary key identity(1,1),
category_id int not null,
product_name varchar(50) not null,
product_description varchar(100),
product_availability int not null,
price int not null,
foreign key (category_id) references Filterr(category_id)
)

create table DescriptionProduct
(
product_id int,
customer_id int,
text_description varchar(300) null,
rating int not null,
foreign key (product_id) references Product(product_id),
foreign key (customer_id) references Users(id),
primary key (product_id, customer_id)
)

create table Cart 
(
cart_id int primary key identity(1,1),
customer_id int not null,
foreign key (customer_id) references Users(id)
)

create table CartItem
(
product_id int not null,
cart_id int not null,
amount int not null,
price int, 
foreign key (product_id) references Product(product_id),
foreign key (cart_id) references Cart(cart_id),
primary key (product_id, cart_id)
)

create table Booking
(
booking_id int primary key identity(1,1), 
cart_id int not null,
price int,
booking_status varchar(20) not null,
delivery varchar(50) not null,
booking_adress varchar(100) not null,
foreign key (cart_id) references Cart(cart_id)
)