-- +goose NO TRANSACTION

-- +goose Up
-- +goose StatementBegin
CREATE UNIQUE INDEX CONCURRENTLY document_reference_values_ref_type_id_display_value_idx
    ON document_reference_values (reference_type_id, display_value);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP INDEX CONCURRENTLY document_reference_values_ref_type_id_display_value_idx;
-- +goose StatementEnd
