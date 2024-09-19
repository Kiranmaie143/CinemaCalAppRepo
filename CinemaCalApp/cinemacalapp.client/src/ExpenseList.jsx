import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Decimal from 'decimal.js';
import '@fortawesome/fontawesome-free/css/all.min.css';

const ExpenseList = () => {
    const [expenses, setExpenses] = useState([]);
    const [newExpense, setNewExpense] = useState({ name: '', price: '', percentageMarkup: '' });
    const [loading, setLoading] = useState(true); // Loading state

    useEffect(() => {
        axios.get('https://localhost:7200/api/Expense') // Use the full URL
            .then(response => {
                console.log(response.data); // Check the response
                setExpenses(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error("There was an error fetching the expenses!", error);
                setLoading(false); 
            });
    }, []);

    const handleAddExpense = () => {
        const { name, price, percentageMarkup } = newExpense;
        const totalPrice = new Decimal(price).plus(new Decimal(price).times(new Decimal(percentageMarkup).dividedBy(100)));

        axios.post('https://localhost:7200/api/Expense', { name, price, percentageMarkup, totalPrice: totalPrice.toString() })
            .then(response => {
                setExpenses([...expenses, response.data]);
                setNewExpense({ name: '', price: '', percentageMarkup: '' });
            })
            .catch(error => {
                console.error('There was an error adding the expense!', error);
            });
    };
    const handleDelete = (id) => {
        axios.delete(`https://localhost:7200/api/Expense/${id}`).then(() => {
            setExpenses(expenses.filter(expense => expense.id !== id));
        });
    };
    const calculateTotalPrice = expenses.reduce((total, expense) => {
        return total.plus(new Decimal(expense.totalPrice || 0));
    }, new Decimal(0));


    return (
        <div className="expense-list">
            <h2>Expense List</h2>
            {loading ? (
                <div className="loading">Loading expenses...</div>
            ) : (
                <>
                    {expenses.length > 0 ? (
                        <div className="expense-items">
                            {expenses.map(expense => (
                                <div key={expense.id} className="expense-item">
                                    <input type="text" value={expense.name} readOnly />
                                    <input type="text" value={expense.price} readOnly />
                                    <input type="text" value={expense.percentageMarkup} readOnly />
                                    <input type="text" value={expense.totalPrice} readOnly />
                                    <button onClick={() => handleDelete(expense.id)} className="delete-button">
                                        <i className="fas fa-trash"></i>
                                    </button>
                                </div>
                            ))}
                        </div>
                    ) : (
                        <p>No expenses found.</p>
                    )}

                        <div className="form-section">
                <input
                    type="text"
                    placeholder="Expense Name"
                    value={newExpense.name}
                    onChange={e => setNewExpense({ ...newExpense, name: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Price"
                    value={newExpense.price}
                    onChange={e => setNewExpense({ ...newExpense, price: e.target.value })}
                />
                <input
                    type="text"
                    placeholder="Markup %"
                    value={newExpense.percentageMarkup}
                    onChange={e => setNewExpense({ ...newExpense, percentageMarkup: e.target.value })}
                />
                <button onClick={handleAddExpense}>Add Expense</button>
            </div>
            <div className="total-price">
                            <h3>Total Price: ${calculateTotalPrice.toFixed(2)}</h3>
                        </div>
                </>
            )}
        </div>
    );
};

export default ExpenseList;