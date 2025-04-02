-- +goose Up
-- +goose StatementBegin
ALTER TABLE document_reference_values
    ADD PRIMARY KEY (reference_type_id, id);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
SELECT 'down SQL query';
-- +goose StatementEnd
