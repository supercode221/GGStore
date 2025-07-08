CREATE DATABASE HoangAnhGGStore;
USE HoangAnhGGStore;

CREATE TABLE categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NTEXT,
    parent_id INT,
    slug NVARCHAR(100) NOT NULL UNIQUE,
    is_active BIT DEFAULT 1,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (parent_id) REFERENCES categories(category_id)
);

CREATE TABLE brands (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    description NTEXT,
    logo_url NVARCHAR(255),
    website NVARCHAR(255),
    is_active BIT DEFAULT 1,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    description NTEXT,
    short_description NVARCHAR(500),
    sku NVARCHAR(100) NOT NULL UNIQUE,
    brand_id INT,
    category_id INT,
    price DECIMAL(10, 2) NOT NULL,
    sale_price DECIMAL(10, 2),
    cost_price DECIMAL(10, 2),
    stock_quantity INT DEFAULT 0,
    min_stock_level INT DEFAULT 5,
    weight DECIMAL(8, 2),
    dimensions NVARCHAR(100),
    warranty_period INT,
    is_featured BIT DEFAULT 0,
    is_active BIT DEFAULT 1,
    meta_title NVARCHAR(255),
    meta_description NTEXT,
    slug NVARCHAR(255) NOT NULL UNIQUE,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE product_attributes (
    attribute_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    type NVARCHAR(20) NOT NULL CHECK (type IN ('text', 'number', 'boolean', 'select', 'multiselect')),
    unit NVARCHAR(20), -- 'dpi', 'hz', 'ms'
    is_filterable BIT DEFAULT 1,
    display_order INT DEFAULT 0,
    created_at DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE product_attribute_values (
    product_id INT,
    attribute_id INT,
    value NVARCHAR(255) NOT NULL,
    PRIMARY KEY (product_id, attribute_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE,
    FOREIGN KEY (attribute_id) REFERENCES product_attributes(attribute_id)
);

CREATE TABLE product_variants (
    variant_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    variant_name NVARCHAR(100),
    sku NVARCHAR(100) NOT NULL UNIQUE,
    price DECIMAL(10, 2),
    sale_price DECIMAL(10, 2),
    stock_quantity INT DEFAULT 0,
    is_active BIT DEFAULT 1,
    created_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE
);

CREATE TABLE product_images (
    image_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT NOT NULL,
    variant_id INT NULL,
    image_url NVARCHAR(255) NOT NULL,
    alt_text NVARCHAR(255),
    is_primary BIT DEFAULT 0,
    display_order INT DEFAULT 0,
    image_type NVARCHAR(20) DEFAULT 'gallery' CHECK (image_type IN ('main', 'gallery', 'thumbnail', 'detail')),
    created_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (variant_id) REFERENCES product_variants(variant_id)
);

CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    email NVARCHAR(255) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    first_name NVARCHAR(100),
    last_name NVARCHAR(100),
    phone NVARCHAR(20),
    date_of_birth DATE,
    is_active BIT DEFAULT 1,
    is_verified BIT DEFAULT 0,
    role NVARCHAR(20) DEFAULT 'customer' CHECK (role IN ('customer', 'admin', 'moderator')),
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE user_addresses (
    address_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    address_type NVARCHAR(20) NOT NULL CHECK (address_type IN ('shipping', 'billing')),
    first_name NVARCHAR(100),
    last_name NVARCHAR(100),
    company NVARCHAR(100),
    address_line1 NVARCHAR(255) NOT NULL,
    address_line2 NVARCHAR(255),
    city NVARCHAR(100) NOT NULL,
    state NVARCHAR(100),
    postal_code NVARCHAR(20) NOT NULL,
    country NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20),
    is_default BIT DEFAULT 0,
    created_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE cart (
    cart_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    session_id NVARCHAR(255),
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE cart_items (
    cart_item_id INT IDENTITY(1,1) PRIMARY KEY,
    cart_id INT,
    product_id INT,
    variant_id INT,
    quantity INT NOT NULL DEFAULT 1,
    price DECIMAL(10, 2) NOT NULL,
    added_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (cart_id) REFERENCES cart(cart_id) ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (variant_id) REFERENCES product_variants(variant_id)
);

CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    order_number NVARCHAR(50) NOT NULL UNIQUE,
    status NVARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'processing', 'shipped', 'delivered', 'cancelled', 'refunded')),
    subtotal DECIMAL(10, 2) NOT NULL,
    tax_amount DECIMAL(10, 2) DEFAULT 0,
    shipping_amount DECIMAL(10, 2) DEFAULT 0,
    discount_amount DECIMAL(10, 2) DEFAULT 0,
    total_amount DECIMAL(10, 2) NOT NULL,
    currency NVARCHAR(3) DEFAULT 'USD',
    payment_status NVARCHAR(20) DEFAULT 'pending' CHECK (payment_status IN ('pending', 'paid', 'failed', 'refunded')),
    payment_method NVARCHAR(50),
    shipping_method NVARCHAR(100),
    notes NTEXT,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE order_items (
    order_item_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    product_id INT,
    variant_id INT,
    product_name NVARCHAR(255) NOT NULL,
    product_sku NVARCHAR(100),
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2) NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL,
    created_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (variant_id) REFERENCES product_variants(variant_id)
);

CREATE TABLE order_addresses (
    address_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    address_type NVARCHAR(20) NOT NULL CHECK (address_type IN ('shipping', 'billing')),
    first_name NVARCHAR(100),
    last_name NVARCHAR(100),
    company NVARCHAR(100),
    address_line1 NVARCHAR(255) NOT NULL,
    address_line2 NVARCHAR(255),
    city NVARCHAR(100) NOT NULL,
    state NVARCHAR(100),
    postal_code NVARCHAR(20) NOT NULL,
    country NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20),
    FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE
);

CREATE TABLE product_reviews (
    review_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    user_id INT,
    rating INT NOT NULL CHECK (rating >= 1 AND rating <= 5),
    title NVARCHAR(255),
    review_text NTEXT,
    is_verified_purchase BIT DEFAULT 0,
    is_approved BIT DEFAULT 0,
    helpful_count INT DEFAULT 0,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE wishlist (
    wishlist_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    product_id INT,
    variant_id INT,
    added_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (variant_id) REFERENCES product_variants(variant_id),
    CONSTRAINT unique_wishlist_item UNIQUE (user_id, product_id, variant_id)
);

CREATE TABLE coupons (
    coupon_id INT IDENTITY(1,1) PRIMARY KEY,
    code NVARCHAR(50) NOT NULL UNIQUE,
    description NVARCHAR(255),
    discount_type NVARCHAR(20) NOT NULL CHECK (discount_type IN ('percentage', 'fixed_amount')),
    discount_value DECIMAL(10, 2) NOT NULL,
    minimum_order_amount DECIMAL(10, 2),
    max_discount_amount DECIMAL(10, 2),
    usage_limit INT,
    used_count INT DEFAULT 0,
    is_active BIT DEFAULT 1,
    valid_from DATETIME2,
    valid_until DATETIME2,
    created_at DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE inventory_transactions (
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    variant_id INT,
    transaction_type NVARCHAR(20) NOT NULL CHECK (transaction_type IN ('in', 'out', 'adjustment')),
    quantity INT NOT NULL,
    reference_type NVARCHAR(20) NOT NULL CHECK (reference_type IN ('purchase', 'sale', 'return', 'adjustment')),
    reference_id INT,
    notes NTEXT,
    created_at DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (variant_id) REFERENCES product_variants(variant_id)
);

-- Create triggers for updating the updated_at columns
CREATE TRIGGER tr_categories_updated_at
ON categories
AFTER UPDATE
AS
BEGIN
    UPDATE categories
    SET updated_at = GETDATE()
    WHERE category_id IN (SELECT category_id FROM inserted)
END;

CREATE TRIGGER tr_brands_updated_at
ON brands
AFTER UPDATE
AS
BEGIN
    UPDATE brands
    SET updated_at = GETDATE()
    WHERE brand_id IN (SELECT brand_id FROM inserted)
END;

CREATE TRIGGER tr_products_updated_at
ON products
AFTER UPDATE
AS
BEGIN
    UPDATE products
    SET updated_at = GETDATE()
    WHERE product_id IN (SELECT product_id FROM inserted)
END;

CREATE TRIGGER tr_users_updated_at
ON users
AFTER UPDATE
AS
BEGIN
    UPDATE users
    SET updated_at = GETDATE()
    WHERE user_id IN (SELECT user_id FROM inserted)
END;

CREATE TRIGGER tr_cart_updated_at
ON cart
AFTER UPDATE
AS
BEGIN
    UPDATE cart
    SET updated_at = GETDATE()
    WHERE cart_id IN (SELECT cart_id FROM inserted)
END;

CREATE TRIGGER tr_orders_updated_at
ON orders
AFTER UPDATE
AS
BEGIN
    UPDATE orders
    SET updated_at = GETDATE()
    WHERE order_id IN (SELECT order_id FROM inserted)
END;

CREATE TRIGGER tr_product_reviews_updated_at
ON product_reviews
AFTER UPDATE
AS
BEGIN
    UPDATE product_reviews
    SET updated_at = GETDATE()
    WHERE review_id IN (SELECT review_id FROM inserted)
END;

-- Sample data for categories
INSERT INTO categories (name, description, slug) VALUES
('Keyboards', 'Mechanical and membrane keyboards for gaming', 'keyboards'),
('Mice', 'Gaming mice with high precision sensors', 'mice'),
('Headsets', 'Gaming headsets and audio equipment', 'headsets'),
('Monitors', 'Gaming monitors and displays', 'monitors'),
('Chairs', 'Gaming chairs and seating solutions', 'chairs'),
('Mousepads', 'Gaming mousepads and desk accessories', 'mousepads'),
('Controllers', 'Gaming controllers and gamepads', 'controllers'),
('Webcams', 'Streaming and gaming webcams', 'webcams');

-- Sample data for brands
INSERT INTO brands (name, description) VALUES
('Logitech', 'Premium gaming peripherals and accessories'),
('Razer', 'High-performance gaming hardware'),
('SteelSeries', 'Professional gaming equipment'),
('Corsair', 'Gaming keyboards, mice, and accessories'),
('HyperX', 'Gaming headsets and memory products'),
('ASUS', 'Gaming monitors and computer hardware'),
('Alienware', 'High-end gaming equipment'),
('Roccat', 'Innovative gaming peripherals');

-- Sample data for product attributes
INSERT INTO product_attributes (name, type, unit, is_filterable) VALUES
('Switch Type', 'select', NULL, 1),
('Backlight', 'select', NULL, 1),
('Wireless', 'boolean', NULL, 1),
('DPI', 'number', 'dpi', 1),
('Polling Rate', 'number', 'hz', 1),
('Driver Size', 'number', 'mm', 1),
('Frequency Response', 'text', 'hz', 0),
('Refresh Rate', 'number', 'hz', 1),
('Resolution', 'text', NULL, 1),
('Panel Type', 'select', NULL, 1);

-- Create indexes for better performance
CREATE INDEX idx_products_category ON products(category_id);
CREATE INDEX idx_products_brand ON products(brand_id);
CREATE INDEX idx_products_active ON products(is_active);
CREATE INDEX idx_products_featured ON products(is_featured);
CREATE INDEX idx_orders_user ON orders(user_id);
CREATE INDEX idx_orders_status ON orders(status);
CREATE INDEX idx_order_items_order ON order_items(order_id);
CREATE INDEX idx_cart_user ON cart(user_id);
CREATE INDEX idx_cart_session ON cart(session_id);
CREATE INDEX idx_reviews_product ON product_reviews(product_id);
CREATE INDEX idx_reviews_user ON product_reviews(user_id);

-- Sample data showing multiple images for a product
-- INSERT INTO product_images (product_id, image_url, alt_text, is_primary, display_order, image_type) VALUES
-- (1, '/images/keyboard-main.jpg', 'Gaming Keyboard Main View', 1, 1, 'main'),
-- (1, '/images/keyboard-side.jpg', 'Gaming Keyboard Side View', 0, 2, 'gallery'),
-- (1, '/images/keyboard-backlight.jpg', 'Gaming Keyboard RGB Backlight', 0, 3, 'gallery'),
-- (1, '/images/keyboard-detail.jpg', 'Gaming Keyboard Key Detail', 0, 4, 'detail');