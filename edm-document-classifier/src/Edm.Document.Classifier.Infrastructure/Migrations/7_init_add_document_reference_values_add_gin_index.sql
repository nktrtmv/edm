-- +goose NO TRANSACTION

-- +goose Up
-- +goose StatementBegin
CREATE INDEX CONCURRENTLY "IX_document_reference_values_display_value_GIN"
    ON document_reference_values using gin ("display_value" collate "und-x-icu" gin_trgm_ops)
    with (fastupdate = false);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP INDEX CONCURRENTLY IX_document_reference_values_display_name_GIN;
-- +goose StatementEnd
