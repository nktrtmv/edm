-- +goose NO TRANSACTION

-- +goose Up
-- +goose StatementBegin
ALTER TABLE document_reference_values
    ADD CONSTRAINT document_reference_values_ref_type_id_display_value
        UNIQUE USING INDEX document_reference_values_ref_type_id_display_value_idx;
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
ALTER TABLE document_reference_values
DROP
CONSTRAINT "document_reference_values_ref_type_id_display_value";
-- +goose StatementEnd
