export const cardTemplate = (card) => html`
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                            <img src="${card.img}" />
                            <p>${card.description}</p>
                            <footer>
                                <p>Price: <span>${card.price} $</span></p>
                            </footer>
                            <div>
                                <a href=”/details/${card._id}” class="btn btn-info">Details</a>
                            </div>
                    </div>
                </div>
            </div>
`;

